using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ftl.SalesCrm.Data;
using Volo.Abp.DependencyInjection;

namespace Ftl.SalesCrm.EntityFrameworkCore;

public class EntityFrameworkCoreSalesCrmDbSchemaMigrator
    : ISalesCrmDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSalesCrmDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the SalesCrmDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SalesCrmDbContext>()
            .Database
            .MigrateAsync();
    }
}
