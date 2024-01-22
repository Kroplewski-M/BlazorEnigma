using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorEnigmaWeb.EnigmaModel;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<IEnigmaService, EnigmaService>();
await builder.Build().RunAsync();
