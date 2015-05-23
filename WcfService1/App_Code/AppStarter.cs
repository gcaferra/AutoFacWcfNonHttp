using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Wcf;

namespace WcfService1.App_Code
{
    public class AppStarter
    {
        public static void AppInitialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Service1>().As<IService1>();

            AutofacHostFactory.Container = builder.Build();
        }

    }
}