using System.Data;
using AspNetCoreHero.EntityFrameworkCore.AuditTrail;
using DGod.SuparCar.Application.Interfaces.Context;
using DGod.SuparCar.Domain.Entities;
using DGod.SuparCar.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DGod.SuparCar.Infrastructure.DbContexts;

public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public IDbConnection Connection => Database.GetDbConnection();

        public bool HasChanges => ChangeTracker.HasChanges();

        public DbSet<EPost> Post { get; set; }
        public DbSet<ETerm> Term { get; set; }
        public DbSet<ETermTaxonomy> TermTaxonomy { get; set; }
        public DbSet<ETermRelationship> TermRelationship { get; set; }
        public DbSet<EOption> Option { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (IMutableEntityType entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName("dg_" + entity.GetTableName().ToLower());
            }
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey((e) => new {e.RoleId, e.UserId});
                entity.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.HasKey((e) => e.Id);
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey((e) => new { e.LoginProvider, e.ProviderKey});
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey((e) =>  new { e.UserId, e.LoginProvider, e.Name });
                entity.ToTable("UserTokens");
            });
        }
    }