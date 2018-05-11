using AutoMapper;
using CoreDbDemo.Model.Domain;
using CoreDbDemo.Repository.Interfaces;
using CoreDbDemo.Strategy.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDbDemo.Strategy
{
    public class RetailerStrategy : IRetailerStrategy
    {
        private readonly IRetailerRepository _retailerRepository;
        private readonly IMapper _mapper;
        public RetailerStrategy(IRetailerRepository retailerRepository,
            IMapper mapper)
        {
            _retailerRepository = retailerRepository;
            _mapper = mapper;
        }
        public async Task<Retailer> Get(int id)
        {
            var retailerDbo = await _retailerRepository.Get(id);
            return _mapper.Map<Retailer>(retailerDbo);
        }
        public async Task<IEnumerable<Retailer>> GetAll()
        {
            var retailerDbos = await _retailerRepository.GetAll();
            return _mapper.Map<IEnumerable<Retailer>>(retailerDbos);
        }
        public async Task<Retailer> GetByStaffMember(StaffMember staffMember)
        {
            return await GetByStaffMember(staffMember.Id);
        }
        public async Task<Retailer> GetByStaffMember(int id)
        {
            var retailerDbo = await _retailerRepository.GetByStaffMember(id);
            return _mapper.Map<Retailer>(retailerDbo);
        }
        public async Task<Retailer> AddOrUpdate(Retailer retailer)
        {
            var retailerDbo = await _retailerRepository.Get(retailer.Id);
            retailerDbo = _mapper.Map(retailer, retailerDbo);

            return _mapper.Map<Retailer>(await _retailerRepository.AddOrUpdate(retailerDbo));
        }
    }
}