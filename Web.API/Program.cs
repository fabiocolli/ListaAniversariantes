using Aplicacao.ManipuladoresDeSinal;
using Aplicacao.Servicos._AmigoAniversariante;
using Aplicacao.Servicos._Pessoa;
using Dominio.Interfaces;
using Dominio.Interfaces.Generico;
using Dominio.Sinais;
using Dominio.Sinais.Compartilhado;
using Dominio.Sinais.Interfaces;
using Infraestrutura.Context;
using Infraestrutura.Repositorios;
using Infraestrutura.Repositorios.Generico;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Contexto>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped(typeof(IGenerico<>), typeof(RepositorioGenerico<>));
builder.Services.AddScoped<IPessoa, RepositorioPessoa>();
builder.Services.AddScoped<IAmigoAniversariante, RepositorioAmigoAniversariante>();
builder.Services.AddScoped<ServicoPessoa>();
builder.Services.AddScoped<ServicoAmigoAniversariante>();
builder.Services.AddScoped<IDespachadorDeSinais, DespachadorDeSinais>();
builder.Services.AddScoped<IManipuladorDeSinal<PessoaCriadaSinal>, PessoaCriadaManipulador>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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
