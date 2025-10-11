using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(sg =>
{
	sg.SwaggerDoc("v1", new OpenApiInfo { Title = "Lista de Aniversariantes", Version = "v1" });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.DefaultModelsExpandDepth(0);
		c.DocExpansion(DocExpansion.None);
	});
}

app.UseAuthorization();

app.MapControllers();

app.Run();
