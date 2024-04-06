using Api;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//��w: �קK��T����A���� Server Header ��T
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
    Log.Information("�����}�l�Ұ�...");

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
    Log.Fatal(ex, "�o�ͥ��w�����~...");

    return 1;
}
finally
{
    Log.CloseAndFlush();
}
