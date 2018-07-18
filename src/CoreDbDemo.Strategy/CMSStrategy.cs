using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreDbDemo.Strategy.Interfaces;
using Umbraco.Headless.Client.Models;
using Umbraco.Headless.Client.Services;
using Umbraco.Headless.Client.Configuration;
using Umbraco.Headless.Client.QueryBuilder;

namespace CoreDbDemo.Strategy
{
    public class CMSStrategy : ICMSStrategy
    {
        private readonly HeadlessService _headlessService;

        public CMSStrategy(HeadlessService headlessService)
        {
            _headlessService = headlessService;
        }

        public async Task<IEnumerable<ContentItem>> GetAllContent()
        {

            var result = await _headlessService
                .Query("nodeName:'Home'")
                //.Where(DefaultProperties.Name)
                //.IsEqualTo("Simple Collection Node")
                .GetAll();
            return result;
        }
    }
}