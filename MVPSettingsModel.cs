using Nop.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.HelloWorldPlugin.Models
{
   public class MVPSettingsModel : CatalogSettingsModel
    {
        [NopResourceDisplayName("MVP.Settings.ShowMVPOnHomepage")]
        public bool ShowMVPOnHomepage { get; set; }
        public bool ShowMVPOnHomepage_OverrideForStore { get; set; }

        [NopResourceDisplayName("MVP.Settings.NumberOfMVPOnHomepage")]
        public int NumberOfMVPOnHomepage { get; set; }
        public bool NumberOfMVPOnHomepage_OverrideForStore { get; set; }
    }
}
