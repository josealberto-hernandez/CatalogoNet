using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogo.Domain.Abstractions;
using Catalogo.Domain.Products.Events;

namespace Catalogo.Domain.Products
{
    public class Product : Entity
    {
        public string? Name {get; set;}
        public decimal? Price {get; set;}
        public string? Description {get; set;}
        public string? ImageUrl {get; set;}
        public Guid CategoryId { get; set;}
public string? Code { get; set;}

        private Product() { }
        private Product(
            Guid id,
            string name,
            decimal price,
            string description,
            string imageUrl,
            string code,
            Guid categoryId
        ) : base(id)
        {
            Name = name;
            Price = price;
            Description = description;
            ImageUrl = imageUrl;
            Code = code;
            CategoryId = categoryId;
        }

        public static Product Create(
            string name,
            decimal price,
            string description,
            string imageUrl,
            string code,
            Guid categoryId
        )
        {
            var product = new Product(Guid.NewGuid(), name, price, description, imageUrl, code, categoryId);
            var productDomainEvent = new ProductCreatedDomainEvent(product.Id);
            product.RaiseDomainEvent(productDomainEvent);
            return product;
        }
    }
}