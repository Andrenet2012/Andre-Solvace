using Solvace.TechCase.Domain.Entities.Produto.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvace.TechCase.Repository.Interface
{
    public interface IProductServices
    {
        Task<ProdutoDto> Create(CreateProduct product);
        Task<ProdutoDto> GetProdutoID(int id);
    }
}
