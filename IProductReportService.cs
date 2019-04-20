using Nop.Core;
using Nop.Plugin.Misc.HelloWorldPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.HelloWorldPlugin.Services
{
   public interface IProductReportService
    {
        IPagedList<MostViewedProduct> MostViewedProducts(
          int categoryId = 0, int manufacturerId = 0,
          int vendorId = 0,
          DateTime? createdFromUtc = null, DateTime? createdToUtc = null,
          int orderBy = 1,
          int pageIndex = 0, int pageSize = int.MaxValue,
          bool showHidden = false);
    }
}
