using Microsoft.EntityFrameworkCore;
using Solvace.TechCase.Domain.Entities.Produto;
using Solvace.TechCase.Domain.Entities.Produto.Dtos;
using Solvace.TechCase.Repository.Contexts;
using Solvace.TechCase.Repository.Interface;
using Solvace.TechCase.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvace.TechCase.Services
{
    public class ProductService : IProductServices
    {
        private readonly DefaultContext _context;

        public ProductService(DefaultContext context)
        {
            _context = context;
        }
        public async Task<ProdutoDto> Create(CreateProduct createProduct)
        {
            try
            {
                var produto = Product.Factories.Create(
                    name: createProduct.Name,
                    description: createProduct.Description,
                    price: createProduct.Price
                );

                await _context.Products.AddAsync(produto);
                await _context.SaveChangesAsync();

                return produto.AsProductDto();
            }
            catch
            {
                throw new ApplicationException("Falhou na criação da Produto");
            }
        }

        public async Task<ProdutoDto> GetProdutoID(int id)
        {
            try
            {
                var product = await _context.Products.AsNoTracking()
                                                .FirstOrDefaultAsync(ap => ap.Id == id);

                if (product == null)
                    throw new KeyNotFoundException("Não foi encontrado produto");

                return product.AsProductDto();
            }
            catch
            {
                throw new ApplicationException("Falha na busca do produto por ID");
            }
        }
    }
}
