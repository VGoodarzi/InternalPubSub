using InternalPubSub.Contracts;
using InternalPubSub.Models;
using Microsoft.Extensions.Hosting;

namespace InternalPubSub.BackgroundServices;

internal class PublishBackgroundService(IPublisher publisher) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        long number = 0;
        while (!stoppingToken.IsCancellationRequested)
        {
            await publisher.Publish(new Message(++number));

            Console.WriteLine("Publish   message with number : {0}", number);

            await Task.Delay(Random.Shared.Next(0, 100), stoppingToken);
        }
    }
}