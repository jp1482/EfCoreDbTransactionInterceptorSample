// See https://aka.ms/new-console-template for more information
using EfCoreInterceptorSample;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

public class ExampleContext : 
    DbContext
{
    public static readonly ILoggerFactory ContextLoggerFactory
        = LoggerFactory.Create(builder => { builder.AddConsole(); });

    public ExampleContext()
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Data Source=(localdb)\\ProjectModels;Initial Catalog=Example;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
        optionsBuilder.UseSqlServer("<<your connection string>>")
            .EnableSensitiveDataLogging(true)
            .UseLoggerFactory(ContextLoggerFactory)
            .AddInterceptors(new ExampleTransactionInterceptor(ContextLoggerFactory));

        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<ExampleEntity> Examples { get; init; }
}
