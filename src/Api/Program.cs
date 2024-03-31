using Api;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//��w: �קK��T����A���� Server Header ��T
builder.WebHost.UseKestrel(option => option.AddServerHeader = false);

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
