using Autofac;
using Autofac.Integration.WebApi;
using EmployeeTest.DataAccessLayer.Repository;
using System.Reflection;
using System.Web.Http;
namespace EmployeeTest.App_Start
{
    public class AutofacWebApi
    {
        public class AutofacWebapiConfig
        {

            public static IContainer Container;

            public static void Initialize(HttpConfiguration config)
            {
                Initialize(config, RegisterServices(new ContainerBuilder()));
            }


            public static void Initialize(HttpConfiguration config, IContainer container)
            {
                config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            }

            private static IContainer RegisterServices(ContainerBuilder builder)
            {
                //Register your Web API controllers.  
                builder.RegisterApiControllers(Assembly.GetExecutingAssembly());



             
                builder.RegisterGeneric(typeof(EmployeeRepository<Models.Employee>))
                       .As(typeof(IEmployeeRepository<Models.Employee>))
                       .InstancePerRequest();

                //Set the dependency resolver to be Autofac.  
                Container = builder.Build();

                return Container;
            }

        }
    }
}