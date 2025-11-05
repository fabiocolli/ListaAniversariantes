using Aplicacao.Dtos.Pessoas;
using Aplicacao.Interfaces;
using Aplicacao.Mapeadores;
using Dominio.Interfaces;
using Dominio.Sinais;
using Dominio.Sinais.Interfaces;

namespace Aplicacao.Servicos._Pessoa
{
	public class ServicoPessoa : IAplicacaoPessoa
	{
		private readonly IPessoa _repositorioPessoa;
		private readonly IDespachadorDeSinais _despachador;
        public ServicoPessoa(IPessoa repositorioPessoa, IDespachadorDeSinais despachador)
        {
            _repositorioPessoa = repositorioPessoa;
            _despachador = despachador;
        }

        public async Task<PessoaDto> Adicionar(PessoaDto objeto)
		{
			var pessoa = MapeadorDaPessoa.ParaEntidade(objeto);

			var pessoaCriada = await _repositorioPessoa.Adicionar(pessoa);

			await _despachador.PublicarAsync(new PessoaCriadaSinal(pessoaCriada));

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
