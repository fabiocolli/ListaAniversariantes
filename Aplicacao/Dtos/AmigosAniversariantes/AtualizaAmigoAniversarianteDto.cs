namespace Aplicacao.Dtos.AmigosAniversariantes
{
    public class AtualizaAmigoAniversarianteDto
    {
        public int IdAmigoAniversariante { get; set; }
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataDoAniversario { get; set; }
    }
}
