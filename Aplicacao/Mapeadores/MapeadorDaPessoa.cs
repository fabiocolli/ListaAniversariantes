using Aplicacao.Dtos.Pessoas;
using Aplicacao.Interfaces;
using Dominio.Entidades;

namespace Aplicacao.Mapeadores
{
	public class MapeadorDaPessoa : IMapeadorBase<PessoaDto, Pessoa>
	{
		public static PessoaDto ParaDto(Pessoa entidade)
		{
			if (entidade == null)
				return null;

			return new PessoaDto
			{
				IdPessoa = entidade.IdPessoa,
				Nome = entidade.Nome,
				DataNascimento = entidade.DataNascimento,
				Idade = CalcularIdade(entidade.DataNascimento)
			};
		}

		public static Pessoa ParaEntidade(PessoaDto dto)
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

		public static IEnumerable<PessoaDto> ParaListaDeDtos(IEnumerable<Pessoa> entidades)
		{
			return entidades?.Select(ParaDto) ?? Enumerable.Empty<PessoaDto>();
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
