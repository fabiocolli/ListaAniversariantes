using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infraestrutura.Context
{
    public class ContextoFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            var opcoesDoContrutor = new DbContextOptionsBuilder<Contexto>();

            opcoesDoContrutor.UseSqlServer("Data Source=fc-p\\local;Initial Catalog=ListaAniversariante;" +
                "Persist Security Info=True;User " +
                "ID=sa;Password=qM1t$up|iC74;TrustServerCertificate=True");

            return new Contexto(opcoesDoContrutor.Options);
        }
    }
}
