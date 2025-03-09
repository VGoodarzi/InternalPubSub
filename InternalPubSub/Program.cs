using InternalPubSub.BackgroundServices;
using InternalPubSub.Contracts;
using InternalPubSub.Decorators;
using InternalPubSub.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = new HostBuilder();

builder.ConfigureServices((context, services) =>
{
    services.AddSingleton<ChannelManager>();
    services.AddSingleton<IPublisher>(sp => sp.GetRequiredService<ChannelManager>());
    services.AddSingleton<ISubscriber>(sp => sp.GetRequiredService<ChannelManager>());
    services.AddSingleton<ChannelStats>();

    services.Decorate<ISubscriber, SubscribeStatsDecorator>();
    services.Decorate<IPublisher, PublishStatsDecorator>();

    services.AddHostedService<ShowStatsBackgroundService>();
    services.AddHostedService<SubscribeBackgroundService>();
    services.AddHostedService<PublishBackgroundService>();
});

var host = builder.Build();

await host.RunAsync();