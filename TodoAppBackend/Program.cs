using Microsoft.Data.SqlClient;
using TodoAppBackend.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

AddDatabaseConnection(builder);
AddServices(builder);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

void AddDatabaseConnection(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("TodoApp");
    builder.Services.AddScoped(_ => new SqlConnection(connectionString));
}
void AddServices(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<UserRepository>();
}