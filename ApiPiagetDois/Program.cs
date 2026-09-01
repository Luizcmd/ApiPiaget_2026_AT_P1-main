using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApiPiagetDois.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ApiPiagetDoisContext");

if (!string.IsNullOrWhiteSpace(connectionString) && connectionString.Contains("Server=", StringComparison.OrdinalIgnoreCase))
{
    builder.Services.AddDbContext<ApiPiagetDoisContext>(options =>
        options.UseSqlServer(connectionString));
}
else
{
    var sqlitePath = Path.Combine(builder.Environment.ContentRootPath, "piaget.db");
    builder.Services.AddDbContext<ApiPiagetDoisContext>(options =>
        options.UseSqlite($"Data Source={sqlitePath}"));
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApiPiagetDoisContext>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();
