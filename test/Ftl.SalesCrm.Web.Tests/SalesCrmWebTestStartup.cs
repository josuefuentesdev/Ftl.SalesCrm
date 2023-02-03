using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Ftl.SalesCrm;

public class SalesCrmWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<SalesCrmWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
