using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Context
{
	public class Contexto : DbContext
	{
		public Contexto(DbContextOptions<Contexto> options) : base(options)
		{

		}

		public DbSet<Pessoa> Pessoas { get; set; }
		public DbSet<AmigoAniversariante> AmigosAniversariantes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(PegarStringConexao());

				base.OnConfiguring(optionsBuilder);
			}
		}
		public string PegarStringConexao()
		{
			return "Data Source=fc-p\\local;Initial Catalog=ListaAniversariante;" +
				"Persist Security Info=True;User " +
				"ID=sa;Password=qM1t$up|iC74;TrustServerCertificate=True";
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Pessoa>(entidade =>
			{
				entidade.HasKey(e => e.IdPessoa);

				entidade.Property(e => e.Nome)
					.IsRequired()
					.HasColumnType("nvarchar")
					.HasMaxLength(100);

				entidade.Property(e => e.DataNascimento)
					.IsRequired()
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<AmigoAniversariante>(entidade =>
			{
				entidade.HasKey(e => e.IdAmigoAniversariante);

				entidade.Property(e => e.Nome)
					.IsRequired()
					.HasColumnType("nvarchar")
					.HasMaxLength(100);

				entidade.Property(e => e.Email)
					.IsRequired()
					.HasColumnType("nvarchar")
					.HasMaxLength(100);

				entidade.Property(e => e.DataDoAniversario)
					.IsRequired()
					.HasColumnType("datetime");

				entidade.HasOne<Pessoa>()
					  .WithMany()
					  .HasForeignKey(e => e.IdPessoa)
					  .OnDelete(DeleteBehavior.Restrict);
			});

			base.OnModelCreating(modelBuilder);
		}
	}
}
