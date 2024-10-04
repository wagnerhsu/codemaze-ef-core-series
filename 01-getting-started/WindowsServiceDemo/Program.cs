using Microsoft.EntityFrameworkCore;
using WindowsServiceDemo;
using WindowsServiceDemo.Models;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Server=.;Database=WindowsServiceDemo;Trusted_Connection=True;");
});

var host = builder.Build();
host.Run();
