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

        // ע����CreateDefaultBuilder�У����Autofac���񹤳�
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;
            //builder.RegisterType<AdvertisementServices>().As<IAdvertisementServices>();


            #region ���нӿڲ�ķ���ע��


            var servicesDllFile = Path.Combine(basePath, "AspNetCoreZhao.WebApi.Services.dll");
            var repositoryDllFile = Path.Combine(basePath, "AspNetCoreZhao.WebApi.Repositorys.dll");

            if (!(File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
            {
                throw new Exception("Repository.dll��service.dll ��ʧ����Ϊ��Ŀ�����ˣ�������Ҫ��F6���룬��F5���У����� bin �ļ��У���������");
            }



            // AOP ���أ������Ҫ��ָ���Ĺ��ܣ�ֻ��Ҫ�� appsettigns.json ��Ӧ��Ӧ true ���С�
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

            // ��ȡ Service.dll ���򼯷��񣬲�ע��
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices)
                      .AsImplementedInterfaces()
                      .InstancePerDependency()
                      .EnableInterfaceInterceptors()//����Autofac.Extras.DynamicProxy;
                      .InterceptedBy(cacheType.ToArray());//����������������б�����ע�ᡣ

            // ��ȡ Repository.dll ���򼯷��񣬲�ע��
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository)
                   .AsImplementedInterfaces()
                   .InstancePerDependency();

            #endregion

            #region û�нӿڲ�ķ����ע��

            //��Ϊû�нӿڲ㣬���Բ���ʵ�ֽ��ֻ���� Load ������
            //ע�����ʹ��û�нӿڵķ��񣬲������ʹ�� AOP ���أ��ͱ�������Ϊ�鷽��
            //var assemblysServicesNoInterfaces = Assembly.Load("Blog.Core.Services");
            //builder.RegisterAssemblyTypes(assemblysServicesNoInterfaces);

            #endregion

            #region û�нӿڵĵ����� class ע��

            //ֻ��ע������е��鷽�����ұ�����public
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(MyLove)))
                .EnableClassInterceptors()
                .InterceptedBy(cacheType.ToArray());

            #endregion

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new Appsettings(Env.ContentRootPath));//ע��appsettings
            services.AddSqlsugarSetup();//ע��sqlsugar


            services.AddAuthorizationSetup();

            services.AddCors(policy=>policy.AddPolicy("LimitRequests", policy =>
            {
                // ֧�ֶ�������˿ڣ�ע��˿ںź�Ҫ��/б�ˣ�����localhost:8000/���Ǵ��
                // ע�⣬http://127.0.0.1:1818 �� http://localhost:1818 �ǲ�һ���ģ�����д����
                policy
                .WithOrigins(Configuration["Startup:Cors:IPs"].Split(','))
                .AllowAnyHeader()//Ensures that the policy allows any header.
                .AllowAnyMethod();
            }));
            services.AddControllers(setup=> {
                setup.ReturnHttpNotAcceptable = true;//����ͺ�˲�һ�·���406
                //setup.OutputFormatters.Add(
                //    new XmlDataContractSerializerOutputFormatter());//���ӷ���xml��ʽ
                //setup.OutputFormatters.Insert(0, new XmlDataContractSerializerOutputFormatter());//xml��ʽ�ŵ�һλ
            }).AddXmlDataContractSerializerFormatters();
            //ע��AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //ע�����
            //services.AddScoped<ICompanyRepository, CompanyRepository>();
            ////ע��DbContext
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
            // ���ش�����
            app.UseStatusCodePages();//�Ѵ����뷵��ǰ̨��������404

            app.UseRouting();
            // �ȿ�����֤
            app.UseAuthentication();
            // Ȼ������Ȩ�м��
            app.UseAuthorization();
            app.UseCors("LimitRequests");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
