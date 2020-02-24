using Microsoft.JSInterop;

namespace EifelMono.Blazor.JavaScript
{
    public static class StorageExtensions
    {
        public static LocalStorageJsInterop LocalStorage(this IJSRuntime thisValue)
            => new LocalStorageJsInterop(thisValue);
        public static LocalStorageJsInterop SessionStorage(this IJSRuntime thisValue)
            => new LocalStorageJsInterop(thisValue);
    }
}
