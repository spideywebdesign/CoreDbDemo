using AutoMapper;
using CoreDbDemo.Model.Domain;
using CoreDbDemo.Model.Entity;
using CoreDbDemo.Repository.Interfaces;
using CoreDbDemo.Strategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreDbDemo.Strategy
{
    public class StaffMemberStrategy : IStaffMemberStrategy
    {
        private readonly IStaffMemberRepository _staffMemberRepository;
        private readonly IMapper _mapper;
        public StaffMemberStrategy(IStaffMemberRepository staffMemberRepository,
            IMapper mapper)
        {
            _staffMemberRepository = staffMemberRepository;
            _mapper = mapper;
        }
        public async Task<StaffMember> Get(int id)
        {
            var staffMemberDbo = await _staffMemberRepository.Get(id);
            return _mapper.Map<StaffMember>(staffMemberDbo);
        }
        public async Task<IEnumerable<StaffMember>> GetAll()
        {
            var staffMemberDbos = await _staffMemberRepository.GetAll();
            return _mapper.Map<IEnumerable<StaffMember>>(staffMemberDbos);
        }
        public async Task<IEnumerable<StaffMember>> GetByRetailer(Retailer retailer)
        {
            return await GetByRetailer(retailer.Id);
        }
        public async Task<IEnumerable<StaffMember>> GetByRetailer(int id)
        {
            var staffMemberDbo = await _staffMemberRepository.GetByRetailer(id);
            return _mapper.Map<IEnumerable<StaffMember>>(staffMemberDbo);
        }
        public async Task<StaffMember> Save(StaffMember staffMember)
        {
            var staffMemberDbo = await _staffMemberRepository.Save(_mapper.Map<StaffMemberDbo>(staffMember));
            return _mapper.Map<StaffMember>(staffMemberDbo);
        }
    }
}
