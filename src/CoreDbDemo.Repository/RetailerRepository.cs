using CoreDbDemo.Common.Logging;
using CoreDbDemo.Data.Context;
using CoreDbDemo.Model.Entity;
using CoreDbDemo.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                Log.Error($"Error in method {nameof(Get)} in {nameof(RetailerRepository)}", ex);
            }

            return items;
        }

        public async Task<RetailerDbo> GetByStaffMember(StaffMemberDbo staffMember)
        {
            throw new NotImplementedException();
        }

        public async Task<RetailerDbo> Save(RetailerDbo retailer)
        {
            throw new NotImplementedException();
        }
    }
}