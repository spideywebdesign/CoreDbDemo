using CoreDbDemo.Common.Logging;
using CoreDbDemo.Data.Context;
using CoreDbDemo.Model.Entity;
using CoreDbDemo.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CoreDbDemo.Repository
{
    public class RetailerRepository : IRetailerRepository
    {
        private readonly CoreDbDemoContext _context;

        public RetailerRepository(CoreDbDemoContext context)
        {
            _context = context;
        }

        public async Task<RetailerDbo> Get(int id)
        {
            RetailerDbo item = null;

            try
            {
                Log.Debug($"{nameof(Get)} called on {nameof(RetailerRepository)} with param id of \"{id}\"");

                item = await _context.Retailers.FirstOrDefaultAsync(x => x.Id == id);

                Log.Debug($"{(item == null ? "0" : "1")} item(s) was found in {nameof(RetailerRepository)} for id \"{id}\"");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(Get)} in {nameof(RetailerRepository)}", ex);
            }

            return item;
        }

        public async Task<IEnumerable<RetailerDbo>> GetAll()
        {
            IEnumerable<RetailerDbo> items = null;

            try
            {
                Log.Debug($"{nameof(Get)} called on {nameof(RetailerRepository)}");

                items = await _context.Retailers.ToListAsync();

                Log.Debug($"{(items == null ? "0" : "1")} item(s) was found in {nameof(RetailerRepository)}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(Get)} in {nameof(RetailerRepository)}", ex);
            }

            return items;
        }

        public async Task<RetailerDbo> GetByStaffMember(StaffMemberDbo staffMember)
        {
            return await GetByStaffMember(staffMember.Id);
        }
        public async Task<RetailerDbo> GetByStaffMember(int id)
        {
            RetailerDbo item = null;

            try
            {
                Log.Debug($"{nameof(GetByStaffMember)} called on {nameof(RetailerRepository)}, id: \"{id}\"");

                var staffMember = await _context.StaffMembers.Include(x => x.Retailer).SingleOrDefaultAsync(x => x.Id == id);//.Result.Retailer;//
                if (staffMember == null) return null;

                item = staffMember.Retailer;

                Log.Debug($"{(item == null ? "0" : "1")} item(s) was found in {nameof(RetailerRepository)} for id: \"{id}\"");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(GetByStaffMember)} in {nameof(RetailerRepository)}", ex);
            }

            return item;
        }

        public async Task<int> AddOrUpdate(RetailerDbo retailer)
        {
            int id = default(int);
            try
            {
                Log.Debug($"{nameof(AddOrUpdate)} called on {nameof(RetailerRepository)}");

                _context.Retailers.Update(retailer);
                id = await _context.SaveChangesAsync();

                Log.Debug($"Retailer saved in method {nameof(AddOrUpdate)} called on {nameof(RetailerRepository)}");
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(AddOrUpdate)} in {nameof(RetailerRepository)}");
            }

            return id;
        }
    }
}