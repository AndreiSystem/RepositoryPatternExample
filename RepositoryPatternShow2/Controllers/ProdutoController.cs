using Microsoft.AspNetCore.Mvc;
using RepositoryPatternShow2.Commons.Repositories;
using RepositoryPatternShow2.Domain;

namespace RepositoryPatternShow2.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
	private readonly IProdutoRepository _produtoRepository;

	public ProdutoController(IProdutoRepository produtoRepository)
	{
		_produtoRepository = produtoRepository;
	}

	[HttpPost(nameof(AdicionarProduto)]
	public async Task<IActionResult> AdicionarProduto()
	{
		var produto = new Produto(Guid.NewGuid(), "Produto 1", 1);

		await _produtoRepository.AddAsync(produto);
		return Ok(produto);
	}
}
