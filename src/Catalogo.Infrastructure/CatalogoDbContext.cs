using Catalogo.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure;

public sealed class CatalogoDbContext : DbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;
    public CatalogoDbContext(DbContextOptions options, IPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(CatalogoDbContext).Assembly);
        base.OnModelCreating(builder);
    }

    public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken=default
    )
    {
        var results = await base.SaveChangesAsync(cancellationToken);
        await PublishNotifications();
        return results;
    }

    private async Task PublishNotifications()
    {
        var domainEventNotifications = ChangeTracker.Entries<Entity>().Select(entry => entry.Entity).SelectMany(entity =>
        {
            var eventNotfications = entity.GetDomainEvents();
            entity.ClearDomainEvents();
            return eventNotfications;
        }).ToList();

        foreach(var eventNotification in domainEventNotifications)
        {
            await _publisher.Publish(eventNotification);
        }
    }


}