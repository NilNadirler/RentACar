using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concentre;
using Castle.DynamicProxy;
using Core.Abstract;
using Core.Concrete;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concentre.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<EfCarDal>().As<ICarDal>();
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();
            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>();
            builder.RegisterType<CarImageManager>().As<ICarImageService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<ZiraatPaymentAdapter>().As<IZiraatPaymentService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<TransactionManager>().As<ITransactionService>();
            builder.RegisterType<EfTransactionDal>().As<ITransactionDal>();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
