using PraPets.Repositories;
using PraPets.Service;
using System;

var builder = WebApplication.CreateBuilder(args);

// Registrar o repositório e a implementação
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Registrar o UsuarioService como um serviço de escopo (Scoped)
builder.Services.AddScoped<UsuarioService>();

// Configuração dos Controllers e Serialização JSON
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Preserve original property names
    options.JsonSerializerOptions.IgnoreNullValues = true;  // Optional: ignore null values
});

// Configuração do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
