using AutoMapper;
using CoreDbDemo.Model.Domain;
using CoreDbDemo.Model.Entity;
using CoreDbDemo.Repository.Interfaces;
using CoreDbDemo.Strategy.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDbDemo.Strategy
{
    public class ExternalSystemStrategy : IExternalSystemStrategy
    {
        private readonly IExternalSystemRepository _externalSystemRepository;
        private readonly IMapper _mapper;

        public ExternalSystemStrategy(IExternalSystemRepository externalSystemRepository,
            IMapper mapper)
        {
            _externalSystemRepository = externalSystemRepository;
            _mapper = mapper;
        }

        public async Task<ExternalSystem> Get(int id)
        {
            var externalSystemDbo = await _externalSystemRepository.Get(id);
            return _mapper.Map<ExternalSystem>(externalSystemDbo);
        }

        public async Task<IEnumerable<ExternalSystem>> GetAll()
        {
            var externalSystemDbos = await _externalSystemRepository.GetAll();
            return _mapper.Map<IEnumerable<ExternalSystem>>(externalSystemDbos);
        }

        public async Task<int> Save(ExternalSystem externalSystem)
        {
            var externalSystemId = await _externalSystemRepository.Save(_mapper.Map<ExternalSystemDbo>(externalSystem));
            return externalSystemId;
        }
    }
}