using Microsoft.EntityFrameworkCore;
using Serilog;
using Topshelf;
using WindowsServiceDemo;
using WindowsServiceDemo.Models;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile(path: "serilog.json", optional: false, reloadOnChange: true)
    .Build();
Directory.SetCurrentDirectory(AppContext.BaseDirectory);    
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

try
{
    HostFactory.Run(x =>
    {
        x.Service<IHost>(s =>
        {
            s.ConstructUsing(name => CreateHostService(args));
            s.WhenStarted(tc =>
            {
                Log.Logger.Information("StartAsync...");
                tc.StartAsync(CancellationToken.None);
            });
            s.WhenStopped(tc =>
            {
                Log.Logger.Information("StopAsync...");
                tc.StopAsync(CancellationToken.None);
            });
        });

        x.RunAsLocalSystem();

        x.SetDescription("WindowsServiceDemo");
        x.SetDisplayName("WindowsServiceDemo");
        x.SetServiceName("WindowsServiceDemo");
    });
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly!");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}


IHost CreateHostService(string[] args)
{
    var builder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder(args);
    builder.Services.AddHostedService<Worker>();
    builder.Services.AddLogging(logging =>
    {
        logging.SetMinimumLevel(LogLevel.Trace);
        logging.ClearProviders();
        logging.AddSerilog();
    });
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    });

    var host = builder.Build();
    return host;
}