using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoreDbDemo.Model.Entity;
using CoreDbDemo.Repository.Interfaces;

namespace CoreDbDemo.Repository
{
    public class RetailerRepository : IRetailerRepository<Retailer>
    {
        public async Task<Retailer> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Retailer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Retailer> GetByStaffMember(StaffMember staffMember)
        {
            throw new NotImplementedException();
        }

        public async Task<Retailer> Save(Retailer retailer)
        {
            throw new NotImplementedException();
        }
    }
}
