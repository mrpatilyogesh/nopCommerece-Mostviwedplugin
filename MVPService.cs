using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Plugin.Misc.HelloWorldPlugin.Models;
using Nop.Services.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.HelloWorldPlugin.Services
{
   public class MVPService : IMVPService
    {

        #region Fields
        private readonly IRepository<MostViewedProduct> _MVPRepository;
        private readonly IRepository<Product> _productCategoryRepository;
        private readonly IWorkContext _workContext;
        private readonly ICategoryService _categoryService;
        private readonly Int32 custid;
        #endregion

        #region CTor
        public MVPService(
            IRepository<MostViewedProduct> MVPRepository,
            IRepository<Product> productCategoryRepository,
            IWorkContext workContext,
            ICategoryService categoryService
            
            )
        {
            _MVPRepository = MVPRepository;
            _productCategoryRepository = productCategoryRepository;
            _workContext = workContext;
            _categoryService = categoryService;
            custid = Convert.ToInt32(_workContext.CurrentCustomer.Id);

        }
        #endregion

        public void Log(Product product)
        {
            var catid = Int32.Parse(_categoryService.GetProductCategoriesByProductId(product.Id).Select(x => x.CategoryId).FirstOrDefault().ToString());
            //var pcatid = Int32.Parse(_categoryService.GetProductCategoriesByCategoryId(catid).Select(x => x.CategoryId).FirstOrDefault().ToString());
            int parentCID =Convert.ToInt32( _categoryService.GetCategoryIdByParentid(Convert.ToInt32(catid)));

            if (parentCID==0)
            {
                parentCID = catid;
            }
            var query = (from p in _MVPRepository.Table
                         where p.ProductId == product.Id
                         select p);

            if (query.Count() == 0)
            {
                MostViewedProduct model = new MostViewedProduct();
                model.ProductId = product.Id;
                model.count = 1;
                model.parentcatid = parentCID;
                model.CategoryId = catid;
                model.CustId = custid;
                _MVPRepository.Insert(model);
            }
            else
            {
                var model = query.First();
                model.count++;
                _MVPRepository.Update(model);
            }
        }
        public virtual IList<MostViewedProduct> GetProductByCategory(int categoryid)
        {
            if (categoryid == 0)
            {
                return null;
            }
            var query = (from m in _MVPRepository.Table
                         where ((m.CategoryId == categoryid) || (m.parentcatid == categoryid)) && (m.CustId == custid)
                         orderby m.count descending
                         select m).Take(3);

            //var query = (from m in _mostviewRepository.Table
            //             where (m.CategoryId == categoryid)  && (m.CustId == customerId)
            //             orderby m.count descending
            //             select m).Take(3);

            return query.ToList();
        }
    }
}
