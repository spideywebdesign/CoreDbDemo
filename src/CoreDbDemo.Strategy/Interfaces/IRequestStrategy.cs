using CoreDbDemo.Model.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDbDemo.Strategy.Interfaces
{
    public interface IRequestStrategy
    {
        /// <summary>
        /// Not sure this is needed as requests will be generated/pulled as part of staff member or retailer?
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Request> Get(int id);
        Task<IEnumerable<Request>> GetAll();
        Task<IEnumerable<Request>> GetByStaffMember(int id);
        Task<int> AddOrUpdate(Request request);
    }
}