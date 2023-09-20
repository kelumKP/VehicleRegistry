#region Using Directives

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
using System;
using System.Net.Http;
using System.Threading.Tasks;

#endregion

namespace YourNamespace
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            #region Service Registrations

            // Register services...
            builder.Services.AddScoped<IBaseService<CategoryDetailsDto>, CategoryService>();
            builder.Services.AddScoped<IBaseService<ManufacturerDto>, ManufacturerService>();
            builder.Services.AddScoped<IBaseService<IconDto>, IconService>();
            builder.Services.AddScoped<IBaseService<VehicleDetailDto>, VehicleDetailService>();

            #endregion

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            #region HttpClient Configuration

            // Configure HttpClient with the base URL
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7154/") // Update this URL as needed
            });

            #endregion

            await builder.Build().RunAsync();
        }
    }
}

