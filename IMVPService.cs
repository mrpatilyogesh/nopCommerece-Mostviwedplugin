using Nop.Core.Domain.Catalog;
using Nop.Plugin.Misc.HelloWorldPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.HelloWorldPlugin.Services
{
    public interface IMVPService
    {
        void Log(Product product);
        IList<MostViewedProduct> GetProductByCategory(int categoryid);
    }
}
