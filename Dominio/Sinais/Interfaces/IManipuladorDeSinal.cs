namespace Dominio.Sinais.Interfaces
{
	public interface IManipuladorDeSinal<TSinal> where TSinal : ISinal
	{
		Task Handle(TSinal sinal);
	}
}
