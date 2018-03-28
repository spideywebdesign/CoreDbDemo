using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDbDemo.Model.Entity
{
    public class ArchivedStaffmember : EntityBase
    {
        // Not sure how this will work yet. We want to track deleted staff members, effectively taking a snapshot of them and their access level(s) at the point of deletion so this can be audited.
    }
}
