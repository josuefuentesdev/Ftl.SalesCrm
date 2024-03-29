﻿using Ftl.SalesCrm.Contacts;
using Ftl.SalesCrm.LeadStatuses;
using Ftl.SalesCrm.Lifecyclestages;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Ftl.SalesCrm.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class SalesCrmDbContext :
    AbpDbContext<SalesCrmDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Lifecyclestage> Lifecyclestages { get; set; }
    public DbSet<LeadStatus> LeadStatuses { get; set; }

    public SalesCrmDbContext(DbContextOptions<SalesCrmDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(SalesCrmConsts.DbTablePrefix + "YourEntities", SalesCrmConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<Contact>(c =>
        {
            c.ToTable(SalesCrmConsts.DbTablePrefix + "Contacts", SalesCrmConsts.DbSchema);
            c.ConfigureByConvention();
            // Contact information
            c.Property(x => x.Firstname).HasMaxLength(50);
            c.Property(x => x.Lastname).HasMaxLength(50);
            c.Property(x => x.Email).HasMaxLength(50);
            c.Property(x => x.Mobilephone).HasMaxLength(50);
            c.Property(x => x.Phone).HasMaxLength(50);
            c.HasOne<Lifecyclestage>().WithMany().HasForeignKey(x => x.LifecyclestageId).IsRequired();
            
            // Sales properties
            c.HasOne<LeadStatus>().WithMany().HasForeignKey(x => x.LeadstatusId).IsRequired();
            c.Property(x => x.Score);
            c.Property(x => x.OwnerAssigneddate);
            c.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.OwnerUserId);
        });

        builder.Entity<Lifecyclestage>(c =>
        {
            c.ToTable(SalesCrmConsts.DbTablePrefix + "Lifecyclestages", SalesCrmConsts.DbSchema);
            c.ConfigureByConvention();
            // Contact information
            c.Property(x => x.Name).HasMaxLength(50);
        });

        builder.Entity<LeadStatus>(c =>
        {
            c.ToTable(SalesCrmConsts.DbTablePrefix + "LeadStatuses", SalesCrmConsts.DbSchema);
            c.ConfigureByConvention();
            // Contact information
            c.Property(x => x.Label).HasMaxLength(50);
            c.Property(x => x.InternalValue).HasMaxLength(50);
        });
    }
}
