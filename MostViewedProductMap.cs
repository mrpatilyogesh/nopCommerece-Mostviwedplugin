using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.HelloWorldPlugin.Models
{
   public class MostViewedProductMap : EntityTypeConfiguration<MostViewedProduct>
    {
        public MostViewedProductMap()
        {
            this.ToTable("ViewCount");
            this.HasKey(c => c.Id);
            this.Property(c => c.CustId);
            this.Property(c => c.CategoryId);
            this.Property(c => c.ProductId);
            this.Property(c => c.count);
            this.Property(c => c.parentcatid);

        }
    }
}
