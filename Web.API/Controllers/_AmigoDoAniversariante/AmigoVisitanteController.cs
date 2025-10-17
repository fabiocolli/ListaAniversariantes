using Aplicacao.Dtos.AmigosAniversariantes;
using Aplicacao.Servicos._AmigoAniversariante;
using Microsoft.AspNetCore.Mvc;
using Web.API.Dtos._AmigoAniversariante;
using Web.API.Mapeadores;

namespace Web.API.Controllers._AmigoDoAniversariante
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmigoVisitanteController : ControllerBase
    {
        private readonly ServicoAmigoAniversariante _servicoAmigoAniversariante;

        public AmigoVisitanteController(ServicoAmigoAniversariante servicoAmigoAniversariante)
        {
            _servicoAmigoAniversariante = servicoAmigoAniversariante;
        }

        [Produces("application/json")]
        [HttpGet("ListarTodosAmigosVisitantes")]
        public async Task<ActionResult<IEnumerable<RespostaAmigoAniversariante>>> ListarTodosAmigosVisitantes()
        {
            var amigosDto = await _servicoAmigoAniversariante.Listar();

            var response = MapeadorDoAmigoAniversariante.ParaListaDeResposta(amigosDto);

            return Ok(response);
        }

        [Produces("application/json")]
        [HttpGet("ObterPorId/{id:int}")]
        public async Task<ActionResult<RespostaAmigoAniversariante>> ObterPorId([FromRoute] int id)
        {
            var amigoDto = await _servicoAmigoAniversariante.BuscarPorId(id);

            if (amigoDto == null)
                return NotFound();

            var response = MapeadorDoAmigoAniversariante.ParaResposta(amigoDto);

            return Ok(response);
        }

        [Produces("application/json")]
        [HttpPost("AdicionarAmigo")]
        public async Task<ActionResult<RespostaAmigoAniversariante>> AdicionarAmigo(
            [FromBody] RequisicaoCriarAmigoAniversariante requisicao)
        {
            var dto = MapeadorDoAmigoAniversariante.ParaAplicacaoDTO(requisicao);

            var amigoDto = new AmigoAniversarianteDto
            {
                IdPessoa = dto.IdPessoa,
                Nome = dto.Nome,
                Email = dto.Email,
                DataDoAniversario = dto.DataDoAniversario
            };

            var amigoCriadoDto = await _servicoAmigoAniversariante.Adicionar(amigoDto);

            var resposta = MapeadorDoAmigoAniversariante.ParaResposta(amigoCriadoDto);

            return CreatedAtAction(
                nameof(ObterPorId),
                new { id = resposta.IdAmigoAniversariante },
                resposta
            );
        }

        [Produces("application/json")]
        [HttpPut("AtualizarAmigo/{id:int}")]
        public async Task<ActionResult> AtualizarAmigo(int id,
            [FromBody] RequisicaoAtualizarAmigoAniversariante requisicao)
        {
            var dto = MapeadorDoAmigoAniversariante.ParaAplicacaoDTO(id, requisicao);

            var amigoDto = new AmigoAniversarianteDto
            {
                IdAmigoAniversariante = dto.IdAmigoAniversariante,
                IdPessoa = dto.IdPessoa,
                Nome = dto.Nome,
                Email = dto.Email,
                DataDoAniversario = dto.DataDoAniversario
            };

            await _servicoAmigoAniversariante.Atualizar(amigoDto);

            return NoContent();
        }

        [Produces("application/json")]
        [HttpDelete("ExcluirAmigo/{id:int}")]
        public async Task<ActionResult> ExcluirAmigo([FromRoute] int id)
        {
            var amigoDto = new AmigoAniversarianteDto
            {
                IdAmigoAniversariante = id
            };

            await _servicoAmigoAniversariante.Excluir(amigoDto);

            return NoContent();
        }
    }
}
