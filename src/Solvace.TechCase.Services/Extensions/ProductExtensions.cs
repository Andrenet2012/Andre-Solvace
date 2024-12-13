

using Solvace.TechCase.Domain.Entities.Produto;
using Solvace.TechCase.Domain.Entities.Produto.Dtos;

namespace Solvace.TechCase.Services.Extensions
{
    public static class ProductExtensions
    {
        public static ProdutoDto AsProductDto(this Product product) => new ProdutoDto
        {
            Id = product.ExternalId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
        };
    }
}
