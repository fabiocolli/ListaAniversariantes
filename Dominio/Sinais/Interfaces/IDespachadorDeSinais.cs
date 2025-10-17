namespace Dominio.Sinais.Interfaces
{
	public interface IDespachadorDeSinais
	{
		Task PublicarAsync<TSinal>(TSinal sinal) where TSinal : ISinal;
	}
}
