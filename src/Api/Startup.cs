using Dao.Utils;
using Infrastructure;
using Serilog;
using Serilog.Events;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region 註冊 Configuration

            services.AddSingleton(Configuration);

            #endregion

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.ToString());
            });
            
            #region 解析 DbSettings

            services.Configure<DbSettings>(Configuration.GetSection("DbSettings"));
            
            // 注入經橋接後被解析的 DbSettings
            services.AddScoped<IDbSettingsResolved, DbSettingsBridge>();

            #endregion

            #region 註冊 ConnectionFactory

            services.AddScoped<IConnectionFactory, ConnectionFactory>();

            #endregion

            #region 每一 Request 都注入一個新實例

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            #region 註冊 功能模組 Service

            IoC.ServiceDependencyInjection.Register(services);

            #endregion

            services.AddHttpContextAccessor();

            //資安: Missing X-Frame Options
            services.AddAntiforgery(option => option.SuppressXFrameOptionsHeader = true);

            //資安: Missing HSTS Header
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(365);
            });

            services.AddServerSideBlazor();

            // Add OpenAPI v3 document
            services.AddOpenApiDocument();

            #region 開啟Https回應壓縮功能

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || (env.IsProduction()))
            {
                app.UseOpenApi();       // serve OpenAPI/Swagger documents
                app.UseSwaggerUi3();    // serve Swagger UI
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiCore v1"));
            }

            app.UseResponseCompression();

            app.UseSerilogRequestLogging(options =>
            {
                // 如果要自訂訊息的範本格式，可以修改這裡，但修改後並不會影響結構化記錄的屬性
                options.MessageTemplate = "Handled {RequestPath}";

                // 預設輸出的紀錄等級為 Information，你可以在此修改記錄等級
                options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Information;

                // 你可以從 httpContext 取得 HttpContext 下所有可以取得的資訊！
                options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                {
                    diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
                    diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
                    diagnosticContext.Set("UserID", httpContext.User.Identity?.Name);
                };
            });

            app.UseRouting();

            #region 指定要使用 Cookie & 使用者認證的中介軟體

            app.UseAuthorization();

            #endregion
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                await next();
            });
        }
    }
}
