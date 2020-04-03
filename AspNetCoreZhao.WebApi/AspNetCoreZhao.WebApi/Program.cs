using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreZhao.WebApi.Data;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspNetCoreZhao.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //Ǩ�����ݿ�
            //using (var scope=host.Services.CreateScope())
            //{
            //    try
            //    {
            //        var dataContext = scope.ServiceProvider.GetService<RoutineDataContext>();
            //        dataContext.Database.EnsureDeleted();//ÿ��ɾ��
            //        dataContext.Database.Migrate();//ÿ��Ǩ��
            //    }
            //    catch (Exception e)
            //    {
            //        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(e,"DataBase Migrate Error!");
            //    }
            //}
             host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //<--NOTE THIS
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://localhost:6000");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
