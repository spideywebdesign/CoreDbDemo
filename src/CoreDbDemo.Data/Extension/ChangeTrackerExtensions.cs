using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using CoreDbDemo.Model.Entity;

namespace CoreDbDemo.Data.Extension
{
    public static class ChangeTrackerExtentions
    {
        public static void ApplyAuditInformation(this ChangeTracker changeTracker)
        {
            foreach (var entry in changeTracker.Entries())
            {
                if (!(entry.Entity is EntityBase entityBase)) continue;

                var now = DateTime.UtcNow;
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entityBase.Created = now;
                        entityBase.Modified = now;
                        break;

                    case EntityState.Added:
                        entityBase.Created = now;
                        break;
                }
            }
        }
    }
}
