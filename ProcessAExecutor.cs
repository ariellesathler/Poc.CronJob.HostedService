using Microsoft.Extensions.Hosting;

namespace Poc.CronJob.HostedService
{
    public class ProcessAExecutor : BackgroundService, IAsyncExecutor
    {
        public Task WhenDone => base.ExecuteTask!;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Start A");

            await Task.Delay(2000, stoppingToken);

            Console.WriteLine("Finish A");
        }
    }

    public class ProcessBExecutor : BackgroundService, IAsyncExecutor
    {
        public Task WhenDone => base.ExecuteTask!; 

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Start B");

            await Task.Delay(5000, stoppingToken);

            Console.WriteLine("Finish  B");
        }
    }

    public interface IAsyncExecutor
    {
        Task WhenDone { get; }
    }

}
