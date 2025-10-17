namespace Web.API.Dtos._AmigoAniversariante
{
	public class RespostaAmigoAniversariante
	{
		public int IdAmigoAniversariante { get; set; }
		public int IdPessoa { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public DateTime DataDoAniversario { get; set; }
		public int Idade => DateTime.Now.Year - DataDoAniversario.Year -
			(DateTime.Now.DayOfYear < DataDoAniversario.DayOfYear ? 1 : 0);
	}
}
