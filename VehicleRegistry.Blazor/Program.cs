using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VehicleRegistry.Application.VehicleDetail;
using VehicleRegistry.Blazor;
using VehicleRegistry.Blazor.Services.VehicleDetail;
using VehicleRegistry.Blazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7154/") });
builder.Services.AddScoped<IBaseService<VehicleDetailDto>, VehicleDetailService>();

await builder.Build().RunAsync();
