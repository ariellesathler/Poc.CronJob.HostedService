using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Poc.CronJob.HostedService;

var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<ProcessAExecutor>();
                services.AddHostedService<ProcessBExecutor>();
            })
            .Build();


using (host)
{
    await host.StartAsync();

    var services = host.Services.GetServices<IHostedService>().Cast<IAsyncExecutor>();
    
    await Task.WhenAll(services.Select(a=> a.WhenDone));

    await host.StopAsync();
}



