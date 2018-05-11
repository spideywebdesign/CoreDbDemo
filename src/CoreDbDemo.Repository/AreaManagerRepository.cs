using CoreDbDemo.Common.Logging;
using CoreDbDemo.Data.Context;
using CoreDbDemo.Model.Entity;
using CoreDbDemo.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CoreDbDemo.Repository
{
    public class AreaManagerRepository : IAreaManagerRepository
    {
        private readonly CoreDbDemoContext _context;

        public AreaManagerRepository(CoreDbDemoContext contact)
        {
            _context = contact;
        }

        public async Task<AreaManagerDbo> Get(int id)
        {
            AreaManagerDbo item = null;

            try
            {
                Log.Debug($"{nameof(Get)} called on {nameof(AreaManagerRepository)} with param id of \"{id}\"");

                item = await _context.AreaManagers.FirstOrDefaultAsync(x => x.Id == id);

                Log.Debug($"{(item == null ? "0" : "1")} item(s) was found in {nameof(AreaManagerRepository)} for id \"{id}\"");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(Get)} in {nameof(AreaManagerRepository)}", ex);
            }

            return item;
        }

        public async Task<IEnumerable<AreaManagerDbo>> GetAll()
        {
            IEnumerable<AreaManagerDbo> items = null;

            try
            {
                Log.Debug($"{nameof(GetAll)} called on {nameof(AreaManagerRepository)}");

                items = await _context.AreaManagers.ToListAsync();

                Log.Debug($"{(items == null ? "0" : "1")} item(s) was found in {nameof(AreaManagerRepository)}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(GetAll)} in {nameof(AreaManagerRepository)}", ex);
            }

            return items;
        }

        public async Task<AreaManagerDbo> AddOrUpdate(AreaManagerDbo areaManager)
        {
            try
            {
                Log.Debug($"{nameof(AddOrUpdate)} called on {nameof(AreaManagerRepository)}");

                _context.AreaManagers.Update(areaManager);
                areaManager.Id = await _context.SaveChangesAsync();

                Log.Debug($"AreaManager saved in method {nameof(AddOrUpdate)} called on {nameof(AreaManagerRepository)}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(AddOrUpdate)} in {nameof(AreaManagerRepository)}");
            }

            return areaManager;
        }
    }
}