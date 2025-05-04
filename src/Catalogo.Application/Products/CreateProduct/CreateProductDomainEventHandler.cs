using Catalogo.Domain.Products.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Products.CreateProduct
{
    internal sealed class CreateProductDomainEventHandler : INotificationHandler<ProductCreatedDomainEvent>
    {
        private readonly ILogger _logger;

        public CreateProductDomainEventHandler(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CreateProductDomainEventHandler>();
        }

        public Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Se ha creado un objeto PRODUCTO {notification.id}");
            return Task.CompletedTask;
        }
    }
}
