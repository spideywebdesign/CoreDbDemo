using System;
using System.Collections.Generic;
using System.Text;
using CoreDbDemo.Data.EntityConfiguration;
using CoreDbDemo.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using CoreDbDemo.Data.Extension;

namespace CoreDbDemo.Data.Context
{
    public class CoreDbDemoContext : DbContext
    {
        public DbSet<StaffMemberDbo> StaffMembers { get; set; }
        public DbSet<RetailerDbo> Retailers { get; set; }
        public DbSet<RequestDbo> Requests { get; set; }
        public DbSet<Model.Entity.ExternalSystemDbo> ExternalSystems { get; set; }
        public DbSet<ArchivedStaffmemberDbo> ArchivedStaffMembers { get; set; }

        public CoreDbDemoContext(DbContextOptions<CoreDbDemoContext> options) : base(options)
        {

        }
        public CoreDbDemoContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            StaffMemberConfiguration.Configure(modelBuilder);
            RetailerConfiguration.Configure(modelBuilder);
            RequestConfiguration.Configure(modelBuilder);
            ExternalSystemConfiguration.Configure(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.ApplyAuditInformation();

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
