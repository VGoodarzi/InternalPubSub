using InternalPubSub.Contracts;
using Microsoft.Extensions.Hosting;

namespace InternalPubSub.BackgroundServices;

internal class SubscribeBackgroundService(ISubscriber subscriber) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var message = await subscriber.Subscribe();

            Console.WriteLine("Subscribe message with number : {0}", message.Number);

            await Task.Delay(Random.Shared.Next(0, 200), stoppingToken);
        }
    }
}