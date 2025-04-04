using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogo.Domain.Abstractions;

namespace Catalogo.Domain.Categories.Events
{
    public sealed record CategoryCreatedDomainEvent(Guid categoryId): IDomainEvent;
}