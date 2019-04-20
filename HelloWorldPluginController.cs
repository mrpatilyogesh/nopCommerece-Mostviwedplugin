
using Nop.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Vendors;
using Nop.Core.Infrastructure;
using Nop.Services.Catalog;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Events;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Shipping;
using Nop.Services.Stores;
using Nop.Services.Tax;
using Nop.Services.Vendors;
using Nop.Services.Configuration;
using Nop.Web.Extensions;
using Nop.Web.Models.Catalog;
using Nop.Plugin.Misc.HelloWorldPlugin.Services;
//using Nop.Web.Factories;
using Nop.Plugin.Misc.HelloWorldPlugin.Factories;
using Nop.Web.Factories;

namespace Nop.Plugin.Misc.HelloWorldPlugin.Controllers
{
    [AdminAuthorize]

    public class HelloWorldPluginController : BasePluginController
    {

        #region Fields
        private readonly ICategoryService _categoryService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IProductService _productService;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IMVPService _mostviewService;
        private readonly IWorkContext _workContext;
        #endregion


        #region CTor
        public HelloWorldPluginController(
            ICategoryService categoryService,
            IManufacturerService manufacturerService,
            IProductService productService,
            IProductModelFactory productModelFactory,
            IMVPService mostviewService,
            IWorkContext workContext
            )
        {
            this._categoryService = categoryService;
            this._manufacturerService = manufacturerService;
            this._productService = productService;
            this._productModelFactory = productModelFactory;
            this._mostviewService = mostviewService;
            this._workContext = workContext;
        }
        #endregion
        public ActionResult configure()

        {
            return View("/Plugins/Misc.HelloWorldPlugin/Views/Configure.cshtml");
        }

        #region PublicInfo
        public ActionResult PublicInfo(int? categoryid)
        {
            var cid = Convert.ToInt32(categoryid);
            var product = _mostviewService.GetProductByCategory(cid);
            int[] id = new Int32[3];
            if (product != null)
            {
                int co = product.Count;
                for (int i = 0; i < co; i++)
                {
                    id[i] = product[i].ProductId;
                }

            }
            var products = _productService.GetProductsByIds(id);

          
            var model = new List<ProductOverviewModel>();


            // model.AddRange(_productModelFactory.Mostviewproducts(products));
            model.AddRange(_productModelFactory.PrepareProductOverviewModels(products));
            return View("~/Plugins/Misc.HelloWorldPlugin/Views/PublicInfo/PublicInfo.cshtml", model);
        }
        #endregion
    }
}
