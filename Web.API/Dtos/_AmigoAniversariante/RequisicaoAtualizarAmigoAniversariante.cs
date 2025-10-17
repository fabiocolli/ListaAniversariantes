namespace Web.API.Dtos._AmigoAniversariante
{
    public class RequisicaoAtualizarAmigoAniversariante
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataDoAniversario { get; set; }
    }
}
