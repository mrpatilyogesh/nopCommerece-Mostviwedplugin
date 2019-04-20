using Autofac;
using Autofac.Core;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.Misc.HelloWorldPlugin.Models;
using Nop.Plugin.Misc.HelloWorldPlugin.Services;
using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nop.Plugin.Misc.HelloWorldPlugin
{
  public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<MVPService>().As<IMVPService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductReportService>().As<IProductReportService>().InstancePerLifetimeScope();
            builder.RegisterType<MVPActionFilter>().As<IFilterProvider>().SingleInstance();
            //data context
            this.RegisterPluginDataContext<MVPObjectContext>(builder, "nop_object_context_mvp");

            //override required repository with our custom context
            builder.RegisterType<EfRepository<MostViewedProduct>>()
                .As<IRepository<MostViewedProduct>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_mvp"))
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 1; }
        }
    }
}