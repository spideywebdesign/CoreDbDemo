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
        public DbSet<StaffMember> StaffMembers { get; set; }
        public DbSet<Retailer> Retailers { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Model.Entity.System> Systems { get; set; }
        public DbSet<ArchivedStaffmember> ArchivedStaffMembers { get; set; }
        
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
            SystemConfiguration.Configure(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.ApplyAuditInformation();

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
