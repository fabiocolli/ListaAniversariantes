using Aplicacao.Dtos.Pessoas;
using Web.API.Dtos._Pessoa;

namespace Web.API.Mapeadores
{
	public static class MapeadorPessoa
	{
		public static CriarPessoaDto ParaAplicacaoDTO(RequisicaCriarPessoa requisicao)
		{
			if (requisicao == null)
				return null;

			return new CriarPessoaDto
			{
				Nome = requisicao.Nome,
				DataNascimento = requisicao.DataNascimento
			};
		}

		public static AtualizarPessoaDto ParaAplicacaoDTO(int id, RequisicaoAtualizarPessoa requisicao)
		{
			if (requisicao == null)
				return null;

			return new AtualizarPessoaDto
			{
				IdPessoa = id,
				Nome = requisicao.Nome,
				DataNascimento = requisicao.DataNascimento
			};
		}

		public static RespostaPessoa ParaResposta(PessoaDto dto)
		{
			if (dto == null)
				return null;

			return new RespostaPessoa
			{
				IdPessoa = dto.IdPessoa,
				Nome = dto.Nome,
				DataNascimento = dto.DataNascimento,
				Idade = dto.Idade
			};
		}

		public static IEnumerable<RespostaPessoa> ParaListaDeResposta(IEnumerable<PessoaDto> dtos)
		{
			return dtos?.Select(ParaResposta) ?? Enumerable.Empty<RespostaPessoa>();
		}
	}
}
