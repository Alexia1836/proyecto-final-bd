using api.estudiante.umg.core.Context;
using api.estudiante.umg.core.Models;
using api.estudiante.umg.core.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// more configurations
builder.Services.AddControllers();

// Injectar las depedencias
builder.Services.AddScoped<Estudiante>();
builder.Services.AddScoped<Cursos>();
builder.Services.AddScoped<EstudianteServices>();
builder.Services.AddScoped<CursoService>();

// Conexion a la base de datos
builder.Services.AddDbContext<EstudianteUMGContext>(options => options.UseSqlServer("Server=172.16.60.250;Database=PRACTICA1; user=sa;password=ProyectoBaseDeDatos2024.; TrustServerCertificate=True;"));


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