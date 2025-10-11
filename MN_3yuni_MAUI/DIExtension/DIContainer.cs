using MN_3yuni_MAUI.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MN_3yuni_MAUI.DIExtension
{
    public static class DIContainer
    {

        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<HomeVM>();
            services.AddTransient<OrderDetailsVM>();
            services.AddTransient<OrderVM>();

            return services;
        }

        public static IServiceCollection RegisterViews(this IServiceCollection services)
        {
            services.AddTransient<MVVM.Views.Home>();
            services.AddTransient<MVVM.Views.OrderPage>();

            return services;
        }
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            return services
                .RegisterViews()
                .RegisterViewModels();
              
        }

    }
}
