using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleRegistry.Application.Category.Commands.CreateCategory;
using VehicleRegistry.Application.Category.Commands.DeleteCategory;
using VehicleRegistry.Application.Category.Commands.UpdateCategory.VehicleRegistry.Application.Category.Commands.UpdateCategory;
using VehicleRegistry.Application.Category.Queries.GetAllCategories;
using VehicleRegistry.Application.Category.Queries.GetCategoryById;
using VehicleRegistry.Application.Category.Services;
using VehicleRegistry.Application.Icon.Commands.CreateIcon;
using VehicleRegistry.Application.Icon.Queries.GetAllIcons;
using VehicleRegistry.Application.Manufacturer.Commands.CreateManufacturer;
using VehicleRegistry.Application.Manufacturer.Queries.GetAllManufacturers;
using VehicleRegistry.Application.VehicleDetail.Commands.CreateVehicleDetail;
using VehicleRegistry.Application.VehicleDetail.Commands.DeleteVehicleDetail;
using VehicleRegistry.Application.VehicleDetail.Commands.UpdateVehicleDetail;
using VehicleRegistry.Application.VehicleDetail.Queries.GetAllVehiclesDetail;
using VehicleRegistry.Application.VehicleDetail.Queries.GetVehicleDetailById;
using VehicleRegistry.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowBlazorOrigin", builder =>
    {
        builder.WithOrigins("https://localhost:7098")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Getting the solution directory path from local folder
static string TryGetSolutionDirectoryInfo(string currentPath = null)
{
    var directory = new DirectoryInfo(
        currentPath ?? Directory.GetCurrentDirectory());
    while (directory != null && !directory.GetFiles("VehicleRegistry.sln").Any())
    {
        directory = directory.Parent;
    }
    return directory?.FullName;
}

// get directory
var solutionDirectory = TryGetSolutionDirectoryInfo();
// if directory found


//adjusting the connection string
builder.Services.AddDbContext<DataContext>(options => {

    // Construct the full path to the database file
    var databaseFilePath = Path.Combine(solutionDirectory, "VehicleRegistry.DAL", "Database", "VehicleRegistryDB.mdf");

    string conn = builder.Configuration.GetConnectionString("DefaultConnection");
    if (conn.Contains("%CONTENTROOTPATH%"))
    {
        conn = conn.Replace("%CONTENTROOTPATH%", databaseFilePath);
    }

    // Use the modified connection string
    options.UseSqlServer(conn);
});

builder.Services.AddScoped<ICategoryValidationService, CategoryValidationService>();

builder.Services.AddMediatR(typeof(GetAllCategoriesQuery));
builder.Services.AddMediatR(typeof(CreateCategoryCommand));
builder.Services.AddMediatR(typeof(DeleteCategoryCommand)); 
builder.Services.AddMediatR(typeof(UpdateCategoryCommand));
builder.Services.AddMediatR(typeof(GetCategoryByIdQuery));

builder.Services.AddMediatR(typeof(GetAllIconsQuery));
builder.Services.AddMediatR(typeof(CreateIconCommand));

builder.Services.AddMediatR(typeof(GetAllManufacturersQuery));
builder.Services.AddMediatR(typeof(CreateManufacturerCommand));

builder.Services.AddMediatR(typeof(GetAllVehiclesDetailsQuery));
builder.Services.AddMediatR(typeof(CreateVehicleDetailCommand));
builder.Services.AddMediatR(typeof(GetVehicleDetailByIdQuery));
builder.Services.AddMediatR(typeof(UpdateVehicleDetailCommand));
builder.Services.AddMediatR(typeof(DeleteVehicleDetailCommand));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowBlazorOrigin");

app.UseHttpsRedirection();

app.UseRouting();   

app.UseAuthorization();

app.MapControllers();

app.Run();
