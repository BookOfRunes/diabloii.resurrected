using Blazored.LocalStorage;
using BookOfRunes.DiabloII.Resurrected.WASM;
using BookOfRunes.DiabloII.Resurrected.WASM.Binders;
using BookOfRunes.DiabloII.Resurrected.WASM.Contexts;
using BookOfRunes.DiabloII.Resurrected.WASM.Controls.Dialog;
using BookOfRunes.DiabloII.Resurrected.WASM.Controls.LoadingScreen;
using BookOfRunes.DiabloII.Resurrected.WASM.Services;
using LightInject;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using STrain;
using STrain.CQS.Blazor.LightInject;
using STrain.CQS.Http.RequestSending.Binders;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.UseLightinject();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddOidcAuthentication(options =>
{
	builder.Configuration.Bind("Authentication", options.ProviderOptions);
	options.ProviderOptions.ResponseType = "code";
});

builder.Services.AddSingleton<IRuneService, RuneService>();
builder.Services.AddSingleton<ICharacterService, CharacterService>();
builder.Services.AddSingleton<IRuneWordService, RuneWordService>();

builder.Services.AddScoped<UserContext>();

builder.Services.AddSingleton<Loading>();
builder.Services.AddSingleton<ILoading>(provider => provider.GetRequiredService<Loading>());

builder.Services.AddSingleton<DialogService>();
builder.Services.AddSingleton<IDialogService>(provider => provider.GetRequiredService<DialogService>());
builder.Services.AddTransient<IMigrationService, MigrationService>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient();
builder.UseRequestRouter(_ => "backend")
	.AddHttpSender("backend", (options, configuration) => configuration.Bind("Backend", options), builder =>
	{
		builder.UseDefaultResponseReader();
		builder.UseGenericBodyParameterBinder();
		builder.UseGenericMethodBinder();
		builder.UseGenericHeaderParameterBinder();
		builder.UseGenericQueryParameterBinder();
		builder.UseGenericRequestErrorHandler();
		builder.UseGenericPathBinder();
	});

builder.ConfigureContainer((container) => container.Decorate(typeof(IHeaderParameterBinder), typeof(AuthorizedGenericHeaderBinder), registration => registration.ServiceName == "backend"));

await builder.Build().RunAsync();
