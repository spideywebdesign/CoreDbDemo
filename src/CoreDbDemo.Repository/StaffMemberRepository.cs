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
    public class StaffMemberRepository : IStaffMemberRepository
    {
        private readonly CoreDbDemoContext _context;

        public StaffMemberRepository(CoreDbDemoContext context)
        {
            _context = context;
        }

        public async Task<StaffMemberDbo> Get(int id)
        {
            StaffMemberDbo item = null;

            try
            {
                Log.Debug($"{nameof(Get)} called on {nameof(StaffMemberRepository)} with param id of \"{id}\"");

                item = await _context.StaffMembers.FirstOrDefaultAsync(x => x.Id == id);

                Log.Debug($"{(item == null ? "0" : "1")} item(s) was found in {nameof(StaffMemberRepository)} for id \"{id}\"");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(Get)} in {nameof(StaffMemberRepository)}", ex);
            }

            return item;
        }

        public async Task<IEnumerable<StaffMemberDbo>> GetAll()
        {
            IEnumerable<StaffMemberDbo> items = null;

            try
            {
                Log.Debug($"{nameof(Get)} called on {nameof(StaffMemberRepository)}");

                items = await _context.StaffMembers.ToListAsync();

                Log.Debug($"{(items == null ? "0" : "1")} item(s) was found in {nameof(StaffMemberRepository)}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(Get)} in {nameof(StaffMemberRepository)}", ex);
            }

            return items;
        }

        public async Task<IEnumerable<StaffMemberDbo>> GetByRetailer(RetailerDbo retailer)
        {
            return await GetByRetailer(retailer.Id);
        }
        public async Task<IEnumerable<StaffMemberDbo>> GetByRetailer(int id)
        {
            IEnumerable<StaffMemberDbo> items = null;

            try
            {
                Log.Debug($"{nameof(GetByRetailer)} called on {nameof(StaffMemberRepository)}, id: \"{id}\"");

                var retailer = await _context.Retailers.Include(x => x.StaffMembers).SingleOrDefaultAsync(x => x.Id == id);//.Result.Retailer;//
                if (retailer == null) return null;
                
                items = retailer.StaffMembers;

                Log.Debug($"{(items == null ? "0" : items.Count().ToString())} item(s) was found in {nameof(StaffMemberRepository)} for id: \"{id}\"");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(GetByRetailer)} in {nameof(StaffMemberRepository)}", ex);
            }

            return items;
        }

        public async Task<int> Save(StaffMemberDbo staffMember)
        {
            int id = default(int);
            try
            {
                Log.Debug($"{nameof(Save)} called on {nameof(StaffMemberRepository)}");

                _context.StaffMembers.Update(staffMember);
                id = await _context.SaveChangesAsync();

                Log.Debug($"StaffMember saved in method {nameof(Save)} called on {nameof(StaffMemberRepository)}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(Save)} in {nameof(StaffMemberRepository)}");
            }

            return id;
        }
    }
}