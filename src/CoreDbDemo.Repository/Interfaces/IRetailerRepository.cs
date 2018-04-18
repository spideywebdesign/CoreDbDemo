using CoreDbDemo.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreDbDemo.Repository.Interfaces
{
    public interface IRetailerRepository<T> where T : new()
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByStaffMember(StaffMember staffMember);
        Task<T> Save(Retailer retailer);
    }
}