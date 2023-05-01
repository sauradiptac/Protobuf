using Application.Service;
using Application.Model;
using Application.Service.IService;
using ProtoBuf;
using Microsoft.Extensions.DependencyInjection;
using Application;

internal class Program
{
    private static void Main(string[] args)
    {
        ServiceCollection services = new ServiceCollection();
        ServiceConfiguration.ConfigureServices(services);
        services
            .AddSingleton<Executor, Executor>()
            .BuildServiceProvider()
            .GetService<Executor>()
            .Execute();

        Console.Read();
    }
}