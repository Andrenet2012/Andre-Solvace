using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvace.TechCase.Domain.Entities.Produto.Dtos
{
    public class CreateProduct
    {
        [MaxLength(255)]
        [MinLength(3)]
        public required string Name { get; set; }
        [MaxLength(4000)]
        [MinLength(3)]
        public required string Description { get; set; }
        public required double Price { get; set; }
    }
}
