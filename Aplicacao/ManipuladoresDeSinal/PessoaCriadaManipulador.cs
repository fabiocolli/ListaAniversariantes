using Dominio.Sinais;
using Dominio.Sinais.Interfaces;

namespace Aplicacao.ManipuladoresDeSinal
{
	public class PessoaCriadaManipulador : IManipuladorDeSinal<PessoaCriadaSinal>
	{

		public Task Handle(PessoaCriadaSinal sinal)
		{
			Console.WriteLine($"Pessoa criada: {sinal.Pessoa.Nome}, " +
				$"Data de Nascimento: {sinal.Pessoa.DataNascimento}");

			return Task.CompletedTask;
		}
	}
}
