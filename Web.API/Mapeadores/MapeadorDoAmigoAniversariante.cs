using Aplicacao.Dtos.AmigosAniversariantes;
using Web.API.Dtos._AmigoAniversariante;

namespace Web.API.Mapeadores
{
    public class MapeadorDoAmigoAniversariante
    {
        public static CriarAmigoAniversarianteDto ParaAplicacaoDTO(
            RequisicaoCriarAmigoAniversariante requisicao)
        {
            if (requisicao == null)
                return null;

            return new CriarAmigoAniversarianteDto
            {
                IdPessoa = requisicao.IdPessoa,
                Nome = requisicao.Nome,
                Email = requisicao.Email,
                DataDoAniversario = requisicao.DataDoAniversario
            };
        }

        public static AtualizaAmigoAniversarianteDto ParaAplicacaoDTO(int id,
            RequisicaoAtualizarAmigoAniversariante requisicao)
        {
            if (requisicao == null)
                return null;

            return new AtualizaAmigoAniversarianteDto
            {
                IdAmigoAniversariante = id,
                IdPessoa = requisicao.IdPessoa,
                Nome = requisicao.Nome,
                Email = requisicao.Email,
                DataDoAniversario = requisicao.DataDoAniversario,
            };
        }

        public static RespostaAmigoAniversariante ParaResposta(AmigoAniversarianteDto dto)
        {
            if (dto == null)
                return null;

            return new RespostaAmigoAniversariante
            {
                IdAmigoAniversariante = dto.IdAmigoAniversariante,
                IdPessoa = dto.IdPessoa,
                Nome = dto.Nome,
                Email = dto.Email,
                DataDoAniversario = dto.DataDoAniversario
            };
        }

        public static IEnumerable<RespostaAmigoAniversariante> ParaListaDeResposta(
            IEnumerable<AmigoAniversarianteDto> dtos)
        {
            return dtos?.Select(ParaResposta) ?? Enumerable.Empty<RespostaAmigoAniversariante>();
        }
    }
}
