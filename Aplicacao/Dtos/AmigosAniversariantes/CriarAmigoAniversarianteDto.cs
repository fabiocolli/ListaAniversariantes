namespace Aplicacao.Dtos.AmigosAniversariantes
{
    public class CriarAmigoAniversarianteDto
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataDoAniversario { get; set; }
    }
}
