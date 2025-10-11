using Aplicacao.Dtos.Pessoas;
using Dominio.Entidades;

namespace Aplicacao.Mapeadores
{
	public static class MapeadorDaPessoa
	{
		public static PessoaDto ParaDto(Pessoa pessoa)
		{
			if (pessoa == null)
				return null;

			return new PessoaDto
			{
				IdPessoa = pessoa.IdPessoa,
				Nome = pessoa.Nome,
				DataNascimento = pessoa.DataNascimento,
				Idade = CalcularIdade(pessoa.DataNascimento)
			};
		}

		public static Pessoa ParaEntidade(PessoaDto dto)
		{
			if (dto == null)
				return null;

			return new Pessoa
			{
				Nome = dto.Nome,
				DataNascimento = dto.DataNascimento
			};
		}

		public static Pessoa ParaEntidadeAtualizar(PessoaDto dto)
		{
			if (dto == null)
				return null;

			return new Pessoa
			{
				IdPessoa = dto.IdPessoa,
				Nome = dto.Nome,
				DataNascimento = dto.DataNascimento
			};
		}

		public static IEnumerable<PessoaDto> ParaListaDeDtos(IEnumerable<Pessoa> pessoas)
		{
			return pessoas?.Select(ParaDto) ?? Enumerable.Empty<PessoaDto>();
		}

		private static int CalcularIdade(DateTime dataNascimento)
		{
			var hoje = DateTime.Today;

			var idade = hoje.Year - dataNascimento.Year;

			if (dataNascimento.Date > hoje.AddYears(-idade))
				idade--;

			return idade;
		}
	}
}
