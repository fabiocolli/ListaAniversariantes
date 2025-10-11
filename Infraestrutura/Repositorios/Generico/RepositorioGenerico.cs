using Dominio.Interfaces.Generico;
using Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Infraestrutura.Repositorios.Generico
{
	public class RepositorioGenerico<T> : IGenerico<T>, IDisposable where T : class
	{
		protected readonly Contexto _contexto;

		public RepositorioGenerico(Contexto contexto)
		{
			_contexto = contexto;
		}

		public async Task<T> Adicionar(T objeto)
		{
			using (var transaction = _contexto.Database.BeginTransaction())
			{
				try
				{
					await _contexto.Set<T>().AddAsync(objeto);

					await SalvaTudo(_contexto);

					await transaction.CommitAsync();

					return objeto;
				}
				catch (Exception)
				{
					await transaction.RollbackAsync();

					throw;
				}
			}
		}

		public async Task<T> Atualizar(T objeto)
		{
			using (var transaction = _contexto.Database.BeginTransaction())
			{
				try
				{
					_contexto.Set<T>().Update(objeto);

					await SalvaTudo(_contexto);

					await transaction.CommitAsync();

					return objeto;
				}
				catch (Exception)
				{
					await transaction.RollbackAsync();

					throw;
				}
			}
		}

		public async Task<T> BuscarPorId(int id)
		{
			return await _contexto.Set<T>().FindAsync(id);
		}

		public async Task<T> Excluir(T objeto)
		{
			_contexto.Set<T>().Remove(objeto);

			await SalvaTudo(_contexto);

			return objeto;
		}

		public async Task<IList<T>> Listar()
		{
			return await _contexto.Set<T>().AsNoTracking().ToListAsync();
		}

		private static async Task SalvaTudo(Contexto dados)
		{
			await dados.SaveChangesAsync();
		}

		//IMPLEMENTAÇÃO DA DOCUMENTAÇÃO DA MICROSOFT

		// Flag: Has Dispose already been called?
		bool disposed = false;
		// Instantiate a SafeHandle instance.
		SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

		// Public implementation of Dispose pattern callable by consumers.
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Protected implementation of Dispose pattern.
		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
				return;

			if (disposing)
			{
				handle.Dispose();
				// Free any other managed objects here.
			}

			disposed = true;
		}
	}
}
