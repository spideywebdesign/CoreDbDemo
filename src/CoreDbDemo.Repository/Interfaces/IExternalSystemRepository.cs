using CoreDbDemo.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDbDemo.Repository.Interfaces
{
    public interface IExternalSystemRepository
    {
        Task<ExternalSystemDbo> Get(int id);
        Task<IEnumerable<ExternalSystemDbo>> GetAll();
        Task<int> Save(ExternalSystemDbo externalSystemDbo);
    }
}