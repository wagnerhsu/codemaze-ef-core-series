using Microsoft.EntityFrameworkCore;
using WindowsServiceDemo;
using WindowsServiceDemo.Models;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var host = builder.Build();
host.Run();
