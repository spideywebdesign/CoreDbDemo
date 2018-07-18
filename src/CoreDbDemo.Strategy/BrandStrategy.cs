using AutoMapper;
using CoreDbDemo.Model.Domain;
using CoreDbDemo.Repository.Interfaces;
using CoreDbDemo.Strategy.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreDbDemo.Model.Entity;

namespace CoreDbDemo.Strategy
{
    public class BrandStrategy : IBrandStrategy
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandStrategy(IBrandRepository brandRepository, IMapper mapper)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public async Task<Brand> Get(int id)
        {
            var brandDbo = await _brandRepository.Get(id);
            return _mapper.Map<Brand>(brandDbo);
        }

        public async Task<IEnumerable<Brand>> GetAll()
        {
            var brandDbos = await _brandRepository.GetAll();
            return _mapper.Map<IEnumerable<Brand>>(brandDbos);
        }

        public async Task<Brand> AddOrUpdate(Brand brand)
        {
            var brandDbo = new BrandDbo();//await _brandRepository.Get(brand.Id);
            brandDbo = _mapper.Map(brand, brandDbo);

            return _mapper.Map<Brand>(await _brandRepository.AddOrUpdate(brandDbo));
        }
    }
}