namespace Aplicacao.Interfaces
{
    public interface IMapeadorBase<TDto, TEntidade>
    {
        static abstract TDto ParaDto(TEntidade entidade);
        static abstract TEntidade ParaEntidade(TDto dto);
        static abstract TEntidade ParaEntidadeAtualizar(TDto dto);
        static abstract IEnumerable<TDto> ParaListaDeDtos(IEnumerable<TEntidade> entidades);
    }
}
