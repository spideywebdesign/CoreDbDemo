using CoreDbDemo.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDbDemo.Repository.Interfaces
{
    public interface IRequestRepository
    {
        /// <summary>
        /// Not sure this is needed as requests will be generated/pulled as part of staff member or retailer?
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RequestDbo> Get(int id);
        Task<IEnumerable<RequestDbo>> GetAll();
        Task<IEnumerable<RequestDbo>> GetByStaffMember(int id);
        Task<int> Save(RequestDbo request);
    }
}