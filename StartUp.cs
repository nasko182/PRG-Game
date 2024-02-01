namespace PRG_Game;

using Microsoft.EntityFrameworkCore;

using Core;
using Data;
using Common;
using Autofac;
using Utilities;
using Services;
using Services.Interfaces;

internal class StartUp
{
    static void Main(string[] args)
    {
        ConsoleWindow.CustomizeConsole();

        var container = ConfigureContainer();

        var application = container.Resolve<Engine>();
        application.Start();
    }


    private static IContainer ConfigureContainer()
    {
        var builder = new ContainerBuilder();

        builder.Register(c =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            string connectionString = DbConfig.ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }).As<ApplicationDbContext>().InstancePerLifetimeScope();

        builder.RegisterType<PlayerService>().As<IPlayerService>();

        builder.RegisterType<Engine>();

        return builder.Build();
    }
}
