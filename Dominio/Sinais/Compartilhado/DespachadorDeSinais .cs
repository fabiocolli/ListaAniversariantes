using Dominio.Sinais.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dominio.Sinais.Compartilhado
{
	public class DespachadorDeSinais : IDespachadorDeSinais
	{
		private readonly IServiceProvider _serviceProvider;

		public DespachadorDeSinais(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public async Task PublicarAsync<TSinal>(TSinal sinal) where TSinal : ISinal
		{
			var handlers = _serviceProvider.GetServices<IManipuladorDeSinal<TSinal>>();

			foreach (var handler in handlers)
			{
				await handler.Handle(sinal);
			}
		}
	}
}
