using Application.Interfaces;
using Domain.Common;
using Domain.Models.Builds;
using Domain.Models.Discounts;
using Domain.Models.Entities;
using Domain.Models.Orders;
using Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

////////////////////////////////////////////////////////////
/// Migration setup
/// PMC project: InfrastructureShared
/// Startup project: WebApi
/// dotnet ef migrations add initial -c ApplicationDbContext -s WebApi --project Infrastructure.Persistence
/// dotnet ef migrations add initial -c ApplicationDbContext // wrong possibly
/// dotnet ef database update -c ApplicationDbContext --project WebApi
////////////////////////////////////////////////////////////


namespace Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<DetailType> DetailTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Build> Builds { get; set; }
        public DbSet<BuildItem> BuildItems { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = _authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //All Decimals will have 18,6 Range
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,6)");
            }
            base.OnModelCreating(builder);
        }
    }
}
