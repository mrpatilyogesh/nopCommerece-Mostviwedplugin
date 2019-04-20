using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.HelloWorldPlugin.Models
{
   public class MostViewedProduct: BaseEntity
    {
        public int CustId { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public int count { get; set; }
        public int parentcatid { get; set; }
    }
}
