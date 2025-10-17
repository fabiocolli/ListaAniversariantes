using Dominio.Sinais.Interfaces;
using System.Collections.Concurrent;

namespace Dominio.Sinais.Compartilhado
{
    public static class Evento
    {
		private static readonly ConcurrentDictionary<Type, List<Delegate>> _handlers = new();

		public static void Registrar<TSinal>(Action<TSinal> handler) where TSinal : ISinal
		{
			var handlers = _handlers.GetOrAdd(typeof(TSinal), _ => new List<Delegate>());

			handlers.Add(handler);
		}

		public static void Publicar<TSinal>(TSinal sinal) where TSinal : ISinal
		{
			if (_handlers.TryGetValue(typeof(TSinal), out var handlers))
			{
				foreach (var handler in handlers.OfType<Action<TSinal>>())
				{
					handler(sinal);
				}
			}
		}
	}
}
