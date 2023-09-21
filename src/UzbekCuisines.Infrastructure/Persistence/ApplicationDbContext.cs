using Duende.IdentityServer.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UzbekCuisines.Application.Common;
using UzbekCuisines.Application.Common.Interfaces;
using UzbekCuisines.Domain.Entities;
using UzbekCuisines.Infrastructure.Identity;
using UzbekCuisines.Infrastructure.Persistence.Interceptors;

namespace UzbekCuisines.Infrastructure.Persistence;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext, IUnitOfWork
{
    private readonly IMediator _mediator;
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        IMediator mediator)
        : base(options, operationalStoreOptions)
    {
        _mediator = mediator;
    }
    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Food> Foods => Set<Food>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}
