using Dominio.Entidades;

namespace Infraestrutura.Mapeadores
{
	public static class MapeadorPessoa
	{
		public static Pessoa ParaDominio(Pessoa pessoa)
		{
			if (pessoa == null)
				return null;

			return new Pessoa
			{
				IdPessoa = pessoa.IdPessoa,
				Nome = pessoa.Nome,
				DataNascimento = pessoa.DataNascimento
			};
		}

		public static Pessoa ParaEntidade(Pessoa pessoa)
		{
			if (pessoa == null)
				return null;

			return new Pessoa
			{
				IdPessoa = pessoa.IdPessoa,
				Nome = pessoa.Nome,
				DataNascimento = pessoa.DataNascimento
			};
		}

		public static IEnumerable<Pessoa> ToDomainList(IEnumerable<Pessoa> entidade)
		{
			return entidade?.Select(ParaDominio) ?? Enumerable.Empty<Pessoa>();
		}
	}
}
