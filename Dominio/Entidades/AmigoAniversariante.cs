namespace Dominio.Entidades
{
	public class AmigoAniversariante
	{
		public int IdAmigoAniversariante { get; set; }
		public int IdPessoa { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public DateTime DataDoAniversario { get; set; }
	}
}
