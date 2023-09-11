using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleRegistry.Application.Category.Commands.CreateCategory;
using VehicleRegistry.Application.Category.Queries.GetAllCategories;
using VehicleRegistry.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

builder.Services.AddMediatR(typeof(GetAllCategoriesQuery));
builder.Services.AddMediatR(typeof(CreateCategoryCommand));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
