using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VehicleRegistry.Application.VehicleDetail;
using VehicleRegistry.Blazor;
using VehicleRegistry.Blazor.Services.VehicleDetail;
using VehicleRegistry.Blazor.Services;
using VehicleRegistry.Application.Category;
using VehicleRegistry.Core.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IBaseService<CategoryDetailsDto>, CategoryService>();
builder.Services.AddScoped<IBaseService<VehicleDetailDto>, VehicleDetailService>();
builder.Services.AddScoped<IBaseService<Manufacturer>, ManufacturerService>();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7154/") });
//builder.Services.AddScoped<CategoryService>();


await builder.Build().RunAsync();
