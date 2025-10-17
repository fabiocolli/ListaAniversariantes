using Aplicacao.Dtos.AmigosAniversariantes;
using Aplicacao.Interfaces.Genericos;
using Aplicacao.Mapeadores;
using Dominio.Interfaces;

namespace Aplicacao.Servicos._AmigoAniversariante
{
    public class ServicoAmigoAniversariante : IGenericoAplicacao<AmigoAniversarianteDto>
    {
        private readonly IAmigoAniversariante _repositorioAmigoAniversariante;

        public ServicoAmigoAniversariante(IAmigoAniversariante repositorioAmigoAniversariante)
        {
            _repositorioAmigoAniversariante = repositorioAmigoAniversariante;
        }

        public async Task<AmigoAniversarianteDto> Adicionar(AmigoAniversarianteDto objeto)
        {
            var entidade = MapeadorDoAmigoAniversariante.ParaEntidade(objeto);

            var criado = await _repositorioAmigoAniversariante.Adicionar(entidade);

            return MapeadorDoAmigoAniversariante.ParaDto(criado);
        }

        public async Task<AmigoAniversarianteDto> Atualizar(AmigoAniversarianteDto objeto)
        {
            var entidade = MapeadorDoAmigoAniversariante.ParaEntidadeAtualizar(objeto);

            await _repositorioAmigoAniversariante.Atualizar(entidade);

            return MapeadorDoAmigoAniversariante.ParaDto(entidade);
        }

        public async Task<AmigoAniversarianteDto> BuscarPorId(int id)
        {
            var entidade = await _repositorioAmigoAniversariante.BuscarPorId(id);

            return MapeadorDoAmigoAniversariante.ParaDto(entidade);
        }

        public async Task<AmigoAniversarianteDto> Excluir(AmigoAniversarianteDto objeto)
        {
            var entidade = MapeadorDoAmigoAniversariante.ParaEntidade(objeto);

            await _repositorioAmigoAniversariante.Excluir(entidade);

            return MapeadorDoAmigoAniversariante.ParaDto(entidade);
        }

        public async Task<IList<AmigoAniversarianteDto>> Listar()
        {
            var lista = await _repositorioAmigoAniversariante.Listar();

            return MapeadorDoAmigoAniversariante.ParaListaDeDtos(lista).ToList();
        }
    }
}
