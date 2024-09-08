using PraPets.Repositories;
using PraPets.Service;
using System;

var builder = WebApplication.CreateBuilder(args);

// Registrar o reposit�rio e a implementa��o
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Registrar o UsuarioService como um servi�o de escopo (Scoped)
builder.Services.AddScoped<UsuarioService>();

// Configura��o dos Controllers e Serializa��o JSON
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Preserve original property names
    options.JsonSerializerOptions.IgnoreNullValues = true;  // Optional: ignore null values
});

// Configura��o do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
