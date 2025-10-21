using Dominio.Sinais.Compartilhado;
using Dominio.Sinais.Interfaces;

namespace Aplicacao.Configuracoes
{
	public static class RegistraManipuladoresDeSinal
	{
		public static void RegistrarManipuladores(this IServiceProvider provedorDeServico)
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();

			foreach (var assembly in assemblies)
			{
				var tiposDeManipuladores = assembly.GetTypes()
					.Where(t => !t.IsAbstract && !t.IsInterface)
					.SelectMany(t => t.GetInterfaces()
						.Where(i => i.IsGenericType &&
							i.GetGenericTypeDefinition() == typeof(IManipuladorDeSinal<>))
						.Select(i => new { ManipuladorType = t, SinalType = i.GetGenericArguments()[0] }));

				foreach (var entrada in tiposDeManipuladores)
				{
					var manipulador = provedorDeServico.GetService(entrada.ManipuladorType);

					if (manipulador == null)
						continue;

					var handleMethod = entrada.ManipuladorType.GetMethod("Handle");

					if (handleMethod == null)
						continue;

					// Cria um delegate para o método Handle
					Action<object> handler = sinal =>
					{
						handleMethod.Invoke(manipulador, new[] { sinal });
					};

					// Registra o handler para o tipo de sinal
					var registrarMethod = typeof(Evento).GetMethod("Registrar")
						.MakeGenericMethod(entrada.SinalType);

					// Adapta o delegate para Action<TSinal>
					var actionType = typeof(Action<>).MakeGenericType(entrada.SinalType);
					var actionDelegate = Delegate.CreateDelegate(actionType, manipulador, handleMethod);

					registrarMethod.Invoke(null, new object[] { actionDelegate });
				}
			}
		}
	}
}
