using Blazored.LocalStorage;
using BookOfRunes.DiabloII.Resurrected.WASM;
using BookOfRunes.DiabloII.Resurrected.WASM.Contexts;
using BookOfRunes.DiabloII.Resurrected.WASM.Controls.Dialog;
using BookOfRunes.DiabloII.Resurrected.WASM.Controls.LoadingScreen;
using BookOfRunes.DiabloII.Resurrected.WASM.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using STrain;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.UseLightinject();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddOidcAuthentication(options =>
{
	builder.Configuration.Bind("Authentication", options.ProviderOptions);
	options.ProviderOptions.ResponseType = "id_token";
});

builder.Services.AddSingleton<IRuneService, RuneService>();
builder.Services.AddSingleton<ICharacterService, CharacterService>();
builder.Services.AddSingleton<IRuneWordService, RuneWordService>();

builder.Services.AddScoped<UserContext>();

builder.Services.AddSingleton<Loading>();
builder.Services.AddSingleton<ILoading>(provider => provider.GetRequiredService<Loading>());

builder.Services.AddSingleton<DialogService>();
builder.Services.AddSingleton<IDialogService>(provider => provider.GetRequiredService<DialogService>());

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient();
builder.UseRequestRouter(_ => "backend")
	.AddGenericHttpSender("backend", (options, configuration) => configuration.Bind("Backend", options));

await builder.Build().RunAsync();
