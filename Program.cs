using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Authorization;
using TennisRD;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TennisRD.Providers;
using TennisRD.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddDevExpressBlazor();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddBlazorise( options =>
    {
        options.Immediate = true;
    } )
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

builder.Services.Configure<DevExpress.Blazor.Configuration.GlobalOptions>(options => {
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
});

// ---------- BLAZOR AUTH
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>(
        provider => new CustomAuthStateProvider(
            provider.GetRequiredService<ILocalStorageService>(),
            provider.GetRequiredService<Supabase.Client>(),
            provider.GetRequiredService<ILogger<CustomAuthStateProvider>>()
        )
    )
    ;
builder.Services.AddAuthorizationCore();

// ---------- SUPABASE
var url = "https://aueimaygxetyltivwsal.supabase.co";
var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImF1ZWltYXlneGV0eWx0aXZ3c2FsIiwicm9sZSI6ImFub24iLCJpYXQiOjE2ODMzMTIyOTQsImV4cCI6MTk5ODg4ODI5NH0.dxdhovHYs4TOoWhNsKruxSivwvc9840vsJ7pILsW29s";

builder.Services.AddScoped<Supabase.Client>(
    provider => new Supabase.Client(
        url,
        key,
        new Supabase.SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true,
            SessionHandler = new CustomSupabaseSessionHandler(
                provider.GetRequiredService<ILocalStorageService>(),
                provider.GetRequiredService<ILogger<CustomSupabaseSessionHandler>>()
            )
        }
    )
);

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<DatabaseService>();
builder.Services.AddScoped<StorageService>();

await builder.Build().RunAsync();
