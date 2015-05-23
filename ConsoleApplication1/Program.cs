using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Wcf;
using WcfService1;

namespace ConsoleApplication1
{
    class Program
    {
     
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.Register(c => new ChannelFactory<IService1>(new NetNamedPipeBinding(), new EndpointAddress("net.pipe://wcfservicelocal/service1.svc"))).SingleInstance();

            builder.Register(c => c.Resolve<ChannelFactory<IService1>>().CreateChannel())
                .As<IService1>()
                .UseWcfSafeRelease();

            var container = builder.Build();
            using (var lifetime = container.BeginLifetimeScope())
            {
                var service = lifetime.Resolve<IService1>();
                var result= service.GetData(1);

                Console.WriteLine("Result {0}",result);
            }
            

        }
    }

   
}
