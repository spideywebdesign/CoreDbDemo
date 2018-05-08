﻿using AutoMapper;
using CoreDbDemo.Model.Domain;
using CoreDbDemo.Model.Entity;
using CoreDbDemo.Repository.Interfaces;
using CoreDbDemo.Strategy.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDbDemo.Strategy
{
    public class RequestStrategy : IRequestStrategy
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;
        public RequestStrategy(IRequestRepository requestRepository,
            IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        public async Task<Request> Get(int id)
        {
            var requestDbo = await _requestRepository.Get(id);
            return _mapper.Map<Request>(requestDbo);
        }

        public async Task<IEnumerable<Request>> GetAll()
        {
            var requestDbos = await _requestRepository.GetAll();
            return _mapper.Map<IEnumerable<Request>>(requestDbos);
        }

        public async Task<IEnumerable<Request>> GetByStaffMember(int id)
        {
            var requestDbos = await _requestRepository.GetByStaffMember(id);
            return _mapper.Map<IEnumerable<Request>>(requestDbos);
        }

        public async Task<int> Save(Request request)
        {
            var requestId = await _requestRepository.Save(_mapper.Map<RequestDbo>(request));
            return requestId;
        }
    }
}