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
    public class BrandRepository : IBrandRepository
    {
        private readonly CoreDbDemoContext _context;

        public BrandRepository(CoreDbDemoContext context)
        {
            _context = context;
        }

        public async Task<BrandDbo> Get(int id)
        {
            BrandDbo item = null;

            try
            {
                Log.Debug($"{nameof(Get)} called on {nameof(BrandRepository)} with param id of \"{id}\"");

                item = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);

                Log.Debug($"{(item == null ? "0" : "1")} item(s) was found in {nameof(BrandRepository)} for id \"{id}\"");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(Get)} in {nameof(BrandRepository)}", ex);
            }

            return item;
        }

        public async Task<IEnumerable<BrandDbo>> GetAll()
        {
            IEnumerable<BrandDbo> items = null;

            try
            {
                Log.Debug($"{nameof(GetAll)} called on {nameof(BrandRepository)}");

                items = await _context.Brands.ToListAsync();

                Log.Debug($"{(items == null ? "0" : "1")} item(s) was found in {nameof(BrandRepository)}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(GetAll)} in {nameof(BrandRepository)}", ex);
            }

            return items;
        }

        public async Task<IEnumerable<BrandDbo>> GetByAreaManager(int id)
        {
            List<BrandDbo> items = null;

            try
            {
                Log.Debug($"{nameof(GetByAreaManager)} called on {nameof(BrandRepository)}, id: \"{id}\"");

                var areaManager = await _context.AreaManagers.Include(x => x.Retailers).ThenInclude(x => x.Brand).SingleOrDefaultAsync(x => x.Id == id);
                if (areaManager == null) return null;

                items = areaManager.Retailers.Select(x => x.Brand).ToList();

                Log.Debug($"{(items.Count().ToString())} item(s) was found in {nameof(BrandRepository)} for id: \"{id}\"");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(GetByAreaManager)} in {nameof(BrandRepository)}", ex);
            }

            return items;
        }

        public async Task<BrandDbo> AddOrUpdate(BrandDbo brand)
        {
            try
            {
                Log.Debug($"{nameof(AddOrUpdate)} called on {nameof(BrandRepository)}");

                _context.Brands.Update(brand);
                brand.Id = await _context.SaveChangesAsync();

                Log.Debug($"Brand saved in method {nameof(AddOrUpdate)} called on {nameof(BrandRepository)}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(AddOrUpdate)} in {nameof(BrandRepository)}");
            }

            return brand;
        }
    }
}