using CoreDbDemo.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreDbDemo.Repository.Interfaces
{
    public interface IRetailerRepository
    {
        Task<RetailerDbo> Get(int id);
        Task<IEnumerable<RetailerDbo>> GetAll();
        Task<RetailerDbo> GetByStaffMember(StaffMemberDbo staffMember);
        Task<RetailerDbo> Save(RetailerDbo retailer);
    }
}