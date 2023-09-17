using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VehicleRegistry.Application.VehicleDetail;
using VehicleRegistry.Blazor;
using VehicleRegistry.Blazor.Services.VehicleDetail;
using VehicleRegistry.Blazor.Services;
using VehicleRegistry.Application.Category;
using VehicleRegistry.Core.Models;
using VehicleRegistry.Blazor.Services.Manufacturer;
using VehicleRegistry.Blazor.Services.Category;
using VehicleRegistry.Application.Manufacturer;
using VehicleRegistry.Application.Icon;
using VehicleRegistry.Blazor.Services.Icon;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IBaseService<CategoryDetailsDto>, CategoryService>();
builder.Services.AddScoped<IBaseService<ManufacturerDto>, ManufacturerService>();
builder.Services.AddScoped<IBaseService<IconDto>, IconService>();
builder.Services.AddScoped<IBaseService<VehicleDetailDto>, VehicleDetailService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7154/") });
//builder.Services.AddScoped<CategoryService>();


await builder.Build().RunAsync();
