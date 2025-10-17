using Aplicacao.Dtos.AmigosAniversariantes;
using Aplicacao.Interfaces;
using Dominio.Entidades;

namespace Aplicacao.Mapeadores
{
    public class MapeadorDoAmigoAniversariante : IMapeadorBase<AmigoAniversarianteDto, AmigoAniversariante>
    {
        public static AmigoAniversarianteDto ParaDto(AmigoAniversariante entidade)
        {
            if (entidade == null)
                return null;

            return new AmigoAniversarianteDto
            {
                IdAmigoAniversariante = entidade.IdAmigoAniversariante,
                IdPessoa = entidade.IdPessoa,
                Nome = entidade.Nome,
                Email = entidade.Email,
                DataDoAniversario = entidade.DataDoAniversario,
                Idade = CalcularIdade(entidade.DataDoAniversario)
            };
        }

        public static AmigoAniversariante ParaEntidade(AmigoAniversarianteDto dto)
        {
            if (dto == null)
                return null;

            return new AmigoAniversariante
            {
                IdAmigoAniversariante = dto.IdAmigoAniversariante,
                IdPessoa = dto.IdPessoa,
                Nome = dto.Nome,
                Email = dto.Email,
                DataDoAniversario = dto.DataDoAniversario
            };
        }

        public static AmigoAniversariante ParaEntidadeAtualizar(AmigoAniversarianteDto dto)
        {
            if (dto == null)
                return null;

            return new AmigoAniversariante
            {
                IdAmigoAniversariante = dto.IdAmigoAniversariante,
                IdPessoa = dto.IdPessoa,
                Nome = dto.Nome,
                Email = dto.Email,
                DataDoAniversario = dto.DataDoAniversario
            };
        }

        public static IEnumerable<AmigoAniversarianteDto> ParaListaDeDtos
            (IEnumerable<AmigoAniversariante> entidades)
        {
            return entidades?.Select(ParaDto) ?? Enumerable.Empty<AmigoAniversarianteDto>();
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
