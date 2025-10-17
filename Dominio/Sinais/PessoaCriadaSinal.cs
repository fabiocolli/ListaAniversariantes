using Dominio.Entidades;
using Dominio.Sinais.Interfaces;
using MediatR;

namespace Dominio.Sinais
{
	public class PessoaCriadaSinal : ISinal
	{
		public Pessoa Pessoa { get; }
		public DateTime DataDoCadastro { get; }

		public PessoaCriadaSinal(Pessoa pessoa)
		{
			Pessoa = pessoa;
			DataDoCadastro = DateTime.UtcNow;
		}
	}
}
