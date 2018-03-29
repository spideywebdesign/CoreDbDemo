using System;
using System.Collections.Generic;
using System.Text;
using CoreDbDemo.Data.Context;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace CoreDbDemo.Data.Seeding
{
    public class SeedDb
    {
        public static void SeedDatabase()
        {
            using (var context = new CoreDbDemoContext())
            {
                for (int i = 0; i < 50; i++)
                {
                    var staffMember
                }
            }
        }
    }
}
