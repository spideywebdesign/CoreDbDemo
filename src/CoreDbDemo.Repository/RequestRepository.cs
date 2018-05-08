using CoreDbDemo.Common.Logging;
using CoreDbDemo.Data.Context;
using CoreDbDemo.Model.Entity;
using CoreDbDemo.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDbDemo.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly CoreDbDemoContext _context;

        public RequestRepository(CoreDbDemoContext context)
        {
            _context = context;
        }

        public async Task<RequestDbo> Get(int id)
        {
            RequestDbo item = null;

            try
            {
                Log.Debug($"{nameof(Get)} called on {nameof(RequestRepository)} with param id of \"{id}\"");

                item = await _context.Requests.FirstOrDefaultAsync(x => x.Id == id);

                Log.Debug($"{(item == null ? "0" : "1")} item(s) was found in {nameof(RequestRepository)} for id \"{id}\"");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(Get)} in {nameof(RequestRepository)}", ex);
            }

            return item;
        }

        public async Task<IEnumerable<RequestDbo>> GetAll()
        {
            IEnumerable<RequestDbo> items = null;

            try
            {
                Log.Debug($"{nameof(GetAll)} called on {nameof(RequestRepository)}");

                items = await _context.Requests.ToListAsync();

                Log.Debug($"{(items == null ? "0" : "1")} item(s) was found in {nameof(RequestRepository)}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(GetAll)} in {nameof(RequestRepository)}", ex);
            }

            return items;
        }

        public async Task<IEnumerable<RequestDbo>> GetByStaffMember(StaffMemberDbo staffMember)
        {
            return await GetByStaffMember(staffMember.Id);
        }
        public async Task<IEnumerable<RequestDbo>> GetByStaffMember(int id)
        {
            IEnumerable<RequestDbo> items = null;

            try
            {
                Log.Debug($"{nameof(GetByStaffMember)} called on {nameof(RequestRepository)}, id: \"{id}\"");

                var staffMember = await _context.StaffMembers.Include(x => x.Requests).SingleOrDefaultAsync(x => x.Id == id);
                if (staffMember == null) return null;

                items = staffMember.Requests;

                Log.Debug($"{(items == null ? "0" : items.Count().ToString())} item(s) was found in {nameof(RequestRepository)} for id: \"{id}\"");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(GetByStaffMember)} in {nameof(RequestRepository)}", ex);
            }

            return items;
        }

        public async Task<int> Save(RequestDbo request)
        {
            int id = default(int);
            try
            {
                Log.Debug($"{nameof(Save)} called on {nameof(RequestRepository)}");

                _context.Requests.Update(request);
                id = await _context.SaveChangesAsync();

                Log.Debug($"StaffMember saved in method {nameof(Save)} called on {nameof(RequestRepository)}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(Save)} in {nameof(RequestRepository)}");
            }

            return id;
        }
    }
}