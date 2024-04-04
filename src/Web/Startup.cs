using Autofac;
using Infrastructure;

namespace Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //#region 註冊 Configuration

            services.AddSingleton(Configuration);

            //#endregion

            //#region 解析 DbSettings

            //services.Configure<DbSettings>(Configuration.GetSection("DbSettings"));

            //// 注入經橋接後被解析的 DbSettings
            //services.AddScoped<IDbSettingsResolved, DbSettingsBridge>();

            //#endregion

            IoC.ServiceDependencyInjection.Register(services);

            services.AddRazorPages();
        }

        //  Using a custom DI container
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Configure custom container.
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
        }
    }
}
