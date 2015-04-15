using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Dejavu.DataAccess.Repository;
using Dejavu.DataAccess.Service;
using Dejavu.Models;
using Telerik.OpenAccess;

namespace Dejavu.App_Start
{
    public class AutofacConfig
    {

        public static void Configure()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModelBinders();
            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly());
            containerBuilder.RegisterFilterProvider();
            containerBuilder.RegisterGeneric(typeof (Repository<>)).As(typeof (IRepository<>)).InstancePerHttpRequest();
            containerBuilder.RegisterType<EntitiesModel>().As<OpenAccessContext>().InstancePerHttpRequest();
            containerBuilder.RegisterModule(new AutofacWebTypesModule());
            containerBuilder.RegisterAssemblyTypes(typeof (ProgramService).Assembly).AsSelf();
            var container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}