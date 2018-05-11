using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreDbDemo.Model.Domain;
using CoreDbDemo.Repository.Interfaces;
using CoreDbDemo.Strategy.Interfaces;

namespace CoreDbDemo.Strategy
{
    public class AreaManagerStrategy : IAreaManagerStrategy
    {
        private readonly IAreaManagerRepository _areaManagerRepository;
        private readonly IMapper _mapper;

        public AreaManagerStrategy(IAreaManagerRepository areaManagerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _areaManagerRepository = areaManagerRepository;
        }

        public async Task<AreaManager> Get(int id)
        {
            var areaManagerDbo = await _areaManagerRepository.Get(id);
            return _mapper.Map<AreaManager>(areaManagerDbo);
        }

        public async Task<IEnumerable<AreaManager>> GetAll()
        {
            var areaManagerDbos = await _areaManagerRepository.GetAll();
            return _mapper.Map<IEnumerable<AreaManager>>(areaManagerDbos);
        }

        public async Task<AreaManager> AddOrUpdate(AreaManager areaManager)
        {
            var areaManagerDbo = await _areaManagerRepository.Get(areaManager.Id);
            areaManagerDbo = _mapper.Map(areaManager, areaManagerDbo);

            return _mapper.Map<AreaManager>(await _areaManagerRepository.AddOrUpdate(areaManagerDbo));
        }
    }
}