using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.HelloWorldPlugin.Models
{
   public class MVPSettings : CatalogSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether to show most viewed on home page
        /// </summary>
        public bool ShowMVPOnHomepage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show most viewed on home page
        /// </summary>
        public int NumberOfMVPOnHomepage { get; set; }
    }
}
