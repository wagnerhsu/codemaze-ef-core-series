using Quartz;

namespace WindowsServiceDemo.Models
{
    public class HelloJob : IJob
    {
        private readonly ILogger<HelloJob> _logger;
        public HelloJob(ILogger<HelloJob> logger)
        {
            this._logger = logger;
        }
        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogDebug($"Hello Job is executing. {DateTime.Now}");
            return Task.CompletedTask;
        }
    }
    
}