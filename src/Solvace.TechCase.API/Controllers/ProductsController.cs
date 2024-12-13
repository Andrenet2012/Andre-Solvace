using Microsoft.AspNetCore.Mvc;
using Solvace.TechCase.Domain.Entities.Produto.Dtos;
using Solvace.TechCase.Repository.Interface;

namespace Solvace.TechCase.API.Controllers;


[ApiController]
[Route("api/produto")]
public class ProductsController : ControllerBase
{
    #region QUESTION 4
    // TYPE YOUR RESPONSE HERE: O Problema era quando criava um novo produto em memoria e fosse pesquisa já perdia a informação.
                            // Para reslver este problema foi criar uma tabela para amarzenar a informação 
    #endregion

    private readonly IProductServices _productService;
    public ProductsController(IProductServices productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        var product = await _productService.GetProdutoID(id);
        return Ok(product);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Product>> Create(CreateProduct product)
    {
        var result = await _productService.Create(product);
        return Created($"/api/produto/{result.Id}", result);
    }
}

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public double Price { get; set; }
}
