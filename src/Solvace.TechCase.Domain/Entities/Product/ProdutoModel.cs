using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvace.TechCase.Domain.Entities.Produto
{
    public class Product : EntityBase
    {
        public int Id { get; set; }
        [MaxLength(255)]
        [MinLength(3)]
        public required string Name { get; set; }
        [MaxLength(4000)]
        [MinLength(3)]
        public required string Description { get; set; }
        public double Price { get; set; }

        public static class Factories
        {
            public static Product Create(string name, string description, double price)
            {
                return new Product
                {
                    Name = name,
                    Description = description,
                    Price = price,
                    ExternalId = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                };
            }
        }
    }
}
