using Aplicacao.Dtos.Pessoas;
using Aplicacao.Interfaces.Genericos;
using Aplicacao.Mapeadores;
using Dominio.Interfaces;

namespace Aplicacao.Servicos._Pessoa
{
	public class ServicoPessoa : IGenericoAplicacao<PessoaDto>
	{
		private readonly IPessoa _repositorioPessoa;

		public ServicoPessoa(IPessoa repositorioPessoa)
		{
			_repositorioPessoa = repositorioPessoa;
		}

		public async Task<PessoaDto> Adicionar(PessoaDto objeto)
		{
			var pessoa = MapeadorDaPessoa.ParaEntidade(objeto);

			var pessoaCriada = await _repositorioPessoa.Adicionar(pessoa);

			return MapeadorDaPessoa.ParaDto(pessoaCriada);
		}

		public async Task<PessoaDto> Atualizar(PessoaDto objeto)
		{
			var pessoa = MapeadorDaPessoa.ParaEntidade(objeto);

			await _repositorioPessoa.Atualizar(pessoa);

			return MapeadorDaPessoa.ParaDto(pessoa);
		}

		public async Task<PessoaDto> BuscarPorId(int id)
		{
			var pessoa = await _repositorioPessoa.BuscarPorId(id);

			return MapeadorDaPessoa.ParaDto(pessoa);
		}

		public async Task<PessoaDto> Excluir(PessoaDto objeto)
		{
			var pessoa = MapeadorDaPessoa.ParaEntidade(objeto);

			await _repositorioPessoa.Excluir(pessoa);

			return MapeadorDaPessoa.ParaDto(pessoa);
		}

		public async Task<IList<PessoaDto>> Listar()
		{
			var pessoas = await _repositorioPessoa.Listar();

			return MapeadorDaPessoa.ParaListaDeDtos(pessoas).ToList();
		}
	}
}
