using CoreDbDemo.Model.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDbDemo.Strategy.Interfaces
{
    public interface IExternalSystemStrategy
    {
        Task<ExternalSystem> Get(int id);
        Task<IEnumerable<ExternalSystem>> GetAll();
        Task<ExternalSystem> AddOrUpdate(ExternalSystem externalSystem);
    }
}