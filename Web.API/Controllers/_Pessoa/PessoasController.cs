using Aplicacao.Dtos.Pessoas;
using Aplicacao.Mapeadores;
using Aplicacao.Servicos._Pessoa;
using Microsoft.AspNetCore.Mvc;
using Web.API.Dtos._Pessoa;
using Web.API.Mapeadores;

namespace Web.API.Controllers._Pessoa
{
	[ApiController]
	[Route("api/[controller]")]
	public class PessoasController : ControllerBase
	{
		private readonly ServicoPessoa _servicoPessoa;

		public PessoasController(ServicoPessoa servicoPessoa)
		{
			_servicoPessoa = servicoPessoa;
		}

		[Produces("application/json")]
		//[HttpPost("AdicionarPessoa")]
		[HttpGet("ListarTodasPessoas")]
		public async Task<ActionResult<IEnumerable<RespostaPessoa>>> ListarTodasPessoas()
		{
			var pessoasDto = await _servicoPessoa.Listar();

			var response = MapeadorPessoa.ParaListaDeResposta(pessoasDto);

			return Ok(response);
		}

		[Produces("application/json")]
		[HttpGet("ObterPorId/{id:int}")]
		public async Task<ActionResult<RespostaPessoa>> ObterPorId([FromRoute] int id)
		{
			var pessoaDto = await _servicoPessoa.BuscarPorId(id);

			if (pessoaDto == null)
				return NotFound();

			var response = MapeadorPessoa.ParaResposta(pessoaDto);

			return Ok(response);
		}

		[Produces("application/json")]
		[HttpPost("AdicionarPessoa")]
		public async Task<ActionResult<RespostaPessoa>> AdicionarPessoa(
			[FromBody] RequisicaCriarPessoa requisicao)
		{
			var dto = MapeadorPessoa.ParaAplicacaoDTO(requisicao);

			var pessoaDto = new PessoaDto
			{
				Nome = dto.Nome,
				DataNascimento = dto.DataNascimento
			};

			var pessoaCriadaDto = await _servicoPessoa.Adicionar(pessoaDto);

			var resposta = MapeadorPessoa.ParaResposta(pessoaCriadaDto);

			return CreatedAtAction(
				nameof(ObterPorId),
				new { id = resposta.IdPessoa },
				resposta
			);
		}

		[Produces("application/json")]
		[HttpPut("AtualizarPessoa/{id:int}")]
		public async Task<ActionResult> AtualizarPessoa(int id, [FromBody]
			RequisicaoAtualizarPessoa requisicao)
		{
			var dto = MapeadorPessoa.ParaAplicacaoDTO(id, requisicao);

			var pessoaDto = new PessoaDto
			{
				IdPessoa = dto.IdPessoa,
				Nome = dto.Nome,
				DataNascimento = dto.DataNascimento
			};

			await _servicoPessoa.Atualizar(pessoaDto);

			return NoContent();
		}

		[Produces("application/json")]
		[HttpDelete("ExcluirPessoa/{id:int}")]
		public async Task<ActionResult> ExcluirPessoa([FromRoute] int id)
		{
			var pessoaDto = new PessoaDto
			{
				IdPessoa = id,
			};

			await _servicoPessoa.Excluir(pessoaDto);

			return NoContent();
		}
	}
}
