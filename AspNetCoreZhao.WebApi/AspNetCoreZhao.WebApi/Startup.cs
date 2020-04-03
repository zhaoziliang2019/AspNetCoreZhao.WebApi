using AspNetCoreZhao.WebApi.Commons;
using AspNetCoreZhao.WebApi.Extensions;
using AspNetCoreZhao.WebApi.Models;
using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AspNetCoreZhao.WebApi
{
    public class Startup
    {
        public IWebHostEnvironment Env { get; }
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration,IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        // 注意在CreateDefaultBuilder中，添加Autofac服务工厂
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;
            //builder.RegisterType<AdvertisementServices>().As<IAdvertisementServices>();


            #region 带有接口层的服务注入


            var servicesDllFile = Path.Combine(basePath, "AspNetCoreZhao.WebApi.Services.dll");
            var repositoryDllFile = Path.Combine(basePath, "AspNetCoreZhao.WebApi.Repositorys.dll");

            if (!(File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
            {
                throw new Exception("Repository.dll和service.dll 丢失，因为项目解耦了，所以需要先F6编译，再F5运行，请检查 bin 文件夹，并拷贝。");
            }



            // AOP 开关，如果想要打开指定的功能，只需要在 appsettigns.json 对应对应 true 就行。
            var cacheType = new List<Type>();
            //if (Appsettings.app(new string[] { "AppSettings", "RedisCachingAOP", "Enabled" }).ObjToBool())
            //{
            //    builder.RegisterType<BlogRedisCacheAOP>();
            //    cacheType.Add(typeof(BlogRedisCacheAOP));
            //}
            //if (Appsettings.app(new string[] { "AppSettings", "MemoryCachingAOP", "Enabled" }).ObjToBool())
            //{
            //    builder.RegisterType<BlogCacheAOP>();
            //    cacheType.Add(typeof(BlogCacheAOP));
            //}
            //if (Appsettings.app(new string[] { "AppSettings", "TranAOP", "Enabled" }).ObjToBool())
            //{
            //    builder.RegisterType<BlogTranAOP>();
            //    cacheType.Add(typeof(BlogTranAOP));
            //}
            //if (Appsettings.app(new string[] { "AppSettings", "LogAOP", "Enabled" }).ObjToBool())
            //{
            //    builder.RegisterType<BlogLogAOP>();
            //    cacheType.Add(typeof(BlogLogAOP));
            //}

            // 获取 Service.dll 程序集服务，并注册
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices)
                      .AsImplementedInterfaces()
                      .InstancePerDependency()
                      .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy;
                      .InterceptedBy(cacheType.ToArray());//允许将拦截器服务的列表分配给注册。

            // 获取 Repository.dll 程序集服务，并注册
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository)
                   .AsImplementedInterfaces()
                   .InstancePerDependency();

            #endregion

            #region 没有接口层的服务层注入

            //因为没有接口层，所以不能实现解耦，只能用 Load 方法。
            //注意如果使用没有接口的服务，并想对其使用 AOP 拦截，就必须设置为虚方法
            //var assemblysServicesNoInterfaces = Assembly.Load("Blog.Core.Services");
            //builder.RegisterAssemblyTypes(assemblysServicesNoInterfaces);

            #endregion

            #region 没有接口的单独类 class 注入

            //只能注入该类中的虚方法，且必须是public
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(MyLove)))
                .EnableClassInterceptors()
                .InterceptedBy(cacheType.ToArray());

            #endregion

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new Appsettings(Env.ContentRootPath));//注入appsettings
            services.AddSqlsugarSetup();//注入sqlsugar


            services.AddAuthorizationSetup();

            services.AddCors(policy=>policy.AddPolicy("LimitRequests", policy =>
            {
                // 支持多个域名端口，注意端口号后不要带/斜杆：比如localhost:8000/，是错的
                // 注意，http://127.0.0.1:1818 和 http://localhost:1818 是不一样的，尽量写两个
                policy
                .WithOrigins(Configuration["Startup:Cors:IPs"].Split(','))
                .AllowAnyHeader()//Ensures that the policy allows any header.
                .AllowAnyMethod();
            }));
            services.AddControllers(setup=> {
                setup.ReturnHttpNotAcceptable = true;//请求和后端不一致返回406
                //setup.OutputFormatters.Add(
                //    new XmlDataContractSerializerOutputFormatter());//增加返回xml格式
                //setup.OutputFormatters.Insert(0, new XmlDataContractSerializerOutputFormatter());//xml格式放第一位
            }).AddXmlDataContractSerializerFormatters();
            //注册AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //注册服务
            //services.AddScoped<ICompanyRepository, CompanyRepository>();
            ////注册DbContext
            //services.AddDbContext<RoutineDataContext>(option=> {
            //    option.UseSqlite(connectionString:"Data Source=routine.Db");
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder=> {
                    appBuilder.Run(async context=> {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Unexpected Error!");
                    });
                });
            }
            // 返回错误码
            app.UseStatusCodePages();//把错误码返回前台，比如是404

            app.UseRouting();
            // 先开启认证
            app.UseAuthentication();
            // 然后是授权中间件
            app.UseAuthorization();
            app.UseCors("LimitRequests");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
