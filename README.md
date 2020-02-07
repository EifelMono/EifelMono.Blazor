# EifelMono.Blazor

Stuff for your Blazor

## Blazor Flow

[See Components in action](https://github.com/EifelMono/EifelMono.Blazor/blob/master/sample/ServerApp/Pages/TestFlow.razor)

### Timer Component
```csharp
<Timer Intervall="@TimeSpan.FromSeconds(10)">@DateTime.Now.ToString()</Timer>

<SecondsTimer Seconds="10">@DateTime.Now.ToString()</SecondsTimer>

<MinutesTimer Minutes="1">@DateTime.Now.ToString()</MinutesTimer>
```

### Debug/Release Component's
```csharp
<Debug>
    <div>We are running in the Debug mode</div>
</Debug>

<Release>
    <div>We are running in the Release mode</div>
</Release>
```

### Log Component's
```csharp
<LogCritical Message="@($"{DateTime.Now} LogCritical")"></LogCritical>
<LogDebug Message="@($"{DateTime.Now} LogDebug")"></LogDebug>
<LogError Message="@($"{DateTime.Now} LogError")"></LogError>
<LogInformation Message="@($"{DateTime.Now} LogInformation")"></LogInformation>
<LogTrace Message="@($"{DateTime.Now} LogTrace")"></LogTrace>
<LogWarning Message="@($"{DateTime.Now} LogWarning")"></LogWarning>
```

### If Component's
```csharp
<If Value="@true">
    <div>If Value is true</div>
</If>

<IfNot Value="@false">
    <div>IfNot Value is false</div>
</IfNot>

<If Value="@true">
    <Then>
        <div>If Then Value is true</div>
    </Then>
    <Else>
        <div>If Else Value is true</div>
    </Else>
</If>
```

### Switch Component's
```csharp
<Switch Value="@DateTime.Now.DayOfWeek">
    <Case Value="@DayOfWeek.Monday">
        Monday
    </Case>
    <Case Value="@DayOfWeek.Sunday">
        Sunday
    </Case>
</Switch>
```

## Blazor Components base 

### code from 

* https://developer.mozilla.org/de/docs/Web/API/Window/sessionStorage



* [Blazaco](https://github.com/Kyle-Undefined/Blazaco)
* [NDCOslo Steve Sanderson](https://github.com/SteveSandersonMS/presentation-2019-06-NDCOslo)
* ....
