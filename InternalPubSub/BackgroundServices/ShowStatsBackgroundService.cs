using InternalPubSub.Implementations;
using Microsoft.Extensions.Hosting;

namespace InternalPubSub.BackgroundServices;

internal class ShowStatsBackgroundService(ChannelStats stats) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            stats.Print();

            await Task.Delay(5000, stoppingToken);
        }
    }
}