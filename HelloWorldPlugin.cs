using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using Nop.Core.Plugins;
using Nop.Services.Common;

namespace Nop.Plugin.Misc.HelloWorldPlugin
{
   public class HelloWorldPlugin :BasePlugin, IMiscPlugin
    {
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "configure";
            controllerName = "HelloWorldPlugin";
            routeValues = new RouteValueDictionary { { "Namespaces", "Nop.Plugin.Misc.HelloWorldPlugin.Controllers" }, { "area", null } };
        }
    }
}
