using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RuneGlossary.Resurrected.WASM;
using RuneGlossary.Resurrected.WASM.Controls;
using RuneGlossary.Resurrected.WASM.Services;
using STrain;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.UseLightinject();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<IRuneService, RuneService>();
builder.Services.AddSingleton<ICharacterService, CharacterService>();
builder.Services.AddSingleton<IRuneWordService, RuneWordService>();

builder.Services.AddSingleton<Loading>();
builder.Services.AddSingleton<ILoading>(provider => provider.GetRequiredService<Loading>());

builder.Services.AddSingleton<DialogService>();
builder.Services.AddSingleton<IDialogService>(provider => provider.GetRequiredService<DialogService>());

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient();
builder.UseRequestRouter(_ => "backend")
	.AddGenericHttpSender("backend", (options, _) =>
	{
		options.BaseAddress = new Uri("http://localhost:5110/");
		options.Path = "api";
	});

await builder.Build().RunAsync();
