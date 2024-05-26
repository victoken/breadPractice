using breadPractice.Mapping;
using breadPractice.Repository.Interfaces;
using breadPractice.Repository.Implements;
using breadPractice.Services.Implements;
using breadPractice.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using breadPractice.DBConnection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string connectionString = builder.Configuration.GetConnectionString("JansBakery");
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));
builder.Services.AddTransient<JanesBakeryConnection>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ServiceMappings));
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
var NorthwindConnecstring = builder.Configuration.GetConnectionString("Northwind");
builder.Services.AddMvc(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
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
