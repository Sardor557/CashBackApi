using CashBackApi.Database.Extensions;
using CashBackApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;
using Toolbelt.ComponentModel.DataAnnotations;

namespace CashBackApi.Database
{
    public partial class MyDbContext : DbContext
    {
        #region DbSet
        public DbSet<spUserType> spUserTypes { get; set; }
        public DbSet<tbCashBack> tbCashBacks { get; set; }
        public DbSet<tbCashBackBalance> tbCashBackBalances { get; set; }
        public DbSet<tbSmsVerification> tbSmsVerifications { get; set; }
        public DbSet<tbUser> tbUsers { get; set; }
        #endregion DbSet

        public MyDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();

            modelBuilder.BuildIndexesFromAnnotations();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbConnection GetDbConnection()
        {
            return Database.GetDbConnection();
        }
    }
}
