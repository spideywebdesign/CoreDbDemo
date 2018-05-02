using CoreDbDemo.Model.Domain;
using CoreDbDemo.Repository.Interfaces;
using CoreDbDemo.Strategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreDbDemo.Model.Entity;

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
        public async Task<Retailer> Save(Retailer retailer)
        {
            var retailerDbo = await _retailerRepository.Save(_mapper.Map<RetailerDbo>(retailer));
            return _mapper.Map<Retailer>(retailerDbo);
        }
    }
}