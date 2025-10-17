using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestrutura.Context;
using Infraestrutura.Repositorios.Generico;

namespace Infraestrutura.Repositorios
{
    public class RepositorioPessoa : RepositorioGenerico<Pessoa>, IPessoa
    {
        public RepositorioPessoa(Contexto contexto) : base(contexto)
        {
        }
    }
}
