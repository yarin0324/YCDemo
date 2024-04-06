using Api;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//資安: 避免橫幅抓取，移除 Server Header 資訊
builder.WebHost.UseKestrel(option => option.AddServerHeader = false);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

// Using a custom DI container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(startup.ConfigureContainer);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

try
{
    Log.Information("網站開始啟動...");

    Host.CreateDefaultBuilder(args)
        .UseSerilog()
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        })
        .Build()
        .Run();

    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "發生未預期錯誤...");

    return 1;
}
finally
{
    Log.CloseAndFlush();
}
