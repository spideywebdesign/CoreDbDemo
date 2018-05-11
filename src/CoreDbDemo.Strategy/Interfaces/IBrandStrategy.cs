using CoreDbDemo.Model.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDbDemo.Strategy.Interfaces
{
    public interface IBrandStrategy
    {
        Task<Brand> Get(int id);
        Task<IEnumerable<Brand>> GetAll();
        Task<Brand> AddOrUpdate(Brand brand);
    }
}