﻿using CoreDbDemo.Common.Logging;
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
    public class ExternalSystemRepository : IExternalSystemRepository
    {
        private readonly CoreDbDemoContext _context;

        public ExternalSystemRepository(CoreDbDemoContext context)
        {
            _context = context;
        }

        public async Task<ExternalSystemDbo> Get(int id)
        {
            ExternalSystemDbo item = null;

            try
            {
                Log.Debug($"{nameof(Get)} called on {nameof(ExternalSystemRepository)} with param id of \"{id}\"");

                item = await _context.ExternalSystems.FirstOrDefaultAsync(x => x.Id == id);

                Log.Debug($"{(item == null ? "0" : "1")} item(s) was found in {nameof(ExternalSystemRepository)} for id \"{id}\"");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(Get)} in {nameof(ExternalSystemRepository)}", ex);
            }

            return item;
        }

        public async Task<IEnumerable<ExternalSystemDbo>> GetAll()
        {
            IEnumerable<ExternalSystemDbo> items = null;

            try
            {
                Log.Debug($"{nameof(GetAll)} called on {nameof(ExternalSystemRepository)}");

                items = await _context.ExternalSystems.ToListAsync();

                Log.Debug($"{(items == null ? "0" : "1")} item(s) was found in {nameof(ExternalSystemRepository)}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(GetAll)} in {nameof(ExternalSystemRepository)}", ex);
            }

            return items;
        }

        public async Task<ExternalSystemDbo> AddOrUpdate(ExternalSystemDbo externalSystem)
        {
            try
            {
                Log.Debug($"{nameof(AddOrUpdate)} called on {nameof(ExternalSystemRepository)}");

                _context.ExternalSystems.Update(externalSystem);
                externalSystem.Id = await _context.SaveChangesAsync();

                Log.Debug($"ExternalSystem saved in method {nameof(AddOrUpdate)} called on {nameof(ExternalSystemRepository)}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Error($"Error in method {nameof(AddOrUpdate)} in {nameof(ExternalSystemRepository)}");
            }

            return externalSystem;
        }
    }
}