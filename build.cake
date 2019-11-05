string target = Argument<string> ("target", "Default");
bool uninstallBeforeInstall = Argument<bool> ("uninstallBeforeInstall", true);

// dotnet tools defaults
string userDirectory = Environment.GetFolderPath (Environment.SpecialFolder.UserProfile);
string dotnetDirectory = System.IO.Path.Combine (userDirectory, ".dotnet");
string dotnetToolsDirectory = System.IO.Path.Combine (dotnetDirectory, "tools");
string dotnetToolsStoreDirectory = System.IO.Path.Combine (dotnetToolsDirectory, ".store");

bool isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform (System.Runtime.InteropServices.OSPlatform.Windows);

string nuGetOrg = "https://api.nuget.org/v3/index.json";



// Name of the csproj 
string csprojName;
string csproj;

// Directory of the package output!!
string nupkgDirectory = "nupkg";

void DotNetRun (string argument) {
    var exitCode = StartProcess ("dotnet", new ProcessSettings {
        Arguments = argument
    });
    if (exitCode != 0)
        throw new Exception ($"Error {exitCode} during cmd={argument}");
}

// pre Tasks 
Setup (ctx => {
    csproj = GetFiles("./src/**/*.csproj").FirstOrDefault().FullPath;
    if (string.IsNullOrEmpty (csproj))
        throw new Exception ($"No csproj file found in this folder {System.IO.Directory.GetCurrentDirectory()}");
    csprojName = System.IO.Path.GetFileNameWithoutExtension (csproj);
});

Teardown (ctx => { });

// Tasks
Task ("Restore")
    .Does (() => {
        DotNetRun ($"restore {csproj}");
    });

Task ("Pack")
    .Does (() => {
        CleanDirectory (nupkgDirectory);
        DotNetRun ($"pack {csproj} -c release -o {nupkgDirectory}");
    });

Task ("Build")
    .Does (() => {
        DotNetRun ($"build {csproj}");
    });

Task ("UnInstall")
    .Description ("Removes an installed tool from the 'user home' .dotnet/tools and .dotnet/tools/.store folder")
    .Does (() => {
        if (DirectoryExists (dotnetToolsDirectory)) {
            var extensions = new string[] { "", ".exe", ".exe.config", ".startupconfig.json" };
            foreach (var extension in extensions) {
                var filename = System.IO.Path.Combine (dotnetToolsDirectory, csprojName) + extension;
                if (System.IO.File.Exists (filename))
                    System.IO.File.Delete (filename);
            }
        }
        if (DirectoryExists (dotnetToolsStoreDirectory)) {
            var dotnetToolStorageDirectory = System.IO.Path.Combine (dotnetToolsStoreDirectory, csprojName);
            if (DirectoryExists (dotnetToolStorageDirectory))
                DeleteDirectory (dotnetToolStorageDirectory, new DeleteDirectorySettings {
                    Force = true,
                    Recursive = true
                });
        }
    });

Task ("UninstallBeforeInstall")
    // If you install again you need to remove the old one by hand
    // at this time needed for 2.1.300 Preview....
    .WithCriteria (uninstallBeforeInstall)
    .IsDependentOn ("UnInstall")
    .Does (() => { });

Task ("InstallFromNuGetLocal")
    .IsDependentOn ("UninstallBeforeInstall")
    .Does (() => {
        DotNetRun ($"tool install {csprojName} --add-source {MakeAbsolute(Directory($"./{nupkgDirectory}"))} -g");
    });

Task ("InstallFromNuGetOrg")
    .IsDependentOn ("UninstallBeforeInstall")
    .Does (() => {
        DotNetRun ($"tool install {csprojName} -g");
    });

Task ("PushToNuGetOrg")
    .Does (() => {
        var nugetNupkgFile = System.IO.Directory.GetFiles (nupkgDirectory, "*.nupkg").FirstOrDefault ();
        if (string.IsNullOrEmpty (nugetNupkgFile))
            throw new Exception ($"No nuget file found in this folder {nupkgDirectory}");
        Information (nugetNupkgFile);
        var exitCode = StartProcess ("nuget", new ProcessSettings {
            Arguments = $"push {nugetNupkgFile} -Source {nuGetOrg}"
        });
    });

Task ("Default")
    .IsDependentOn ("Restore")
    .IsDependentOn ("Pack")
    .IsDependentOn ("InstallFromNuGetLocal")
    .Does (() => { });

RunTarget (target);
