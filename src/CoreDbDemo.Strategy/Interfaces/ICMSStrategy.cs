using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Headless.Client.Models;

namespace CoreDbDemo.Strategy.Interfaces
{
    public interface ICMSStrategy
    {
        Task<IEnumerable<ContentItem>> GetAllContent();
    }
}
