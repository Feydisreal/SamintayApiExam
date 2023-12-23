using Microsoft.Extensions.DependencyInjection;
using SaminrayApiExam.Core.Services;
using SaminrayApiExam.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaminrayApiExam.Core.DependencyInjections
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddAllServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductGroupService, ProductGroupService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReceiptService, ReceiptService>();
            

            return services;
        }
    }
}
