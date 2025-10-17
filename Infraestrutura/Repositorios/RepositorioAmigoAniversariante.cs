using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestrutura.Context;
using Infraestrutura.Repositorios.Generico;

namespace Infraestrutura.Repositorios
{
    public class RepositorioAmigoAniversariante : RepositorioGenerico<AmigoAniversariante>, IAmigoAniversariante
    {
        public RepositorioAmigoAniversariante(Contexto contexto) : base(contexto)
        {
        }
    }
}
