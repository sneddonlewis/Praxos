using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Praxos.Application.Contracts.Persistence;
using Praxos.Persistence.Repos;

namespace Praxos.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        return services
            .AddScoped<DbConnection>(sp => new SqliteConnection(connectionString))
            .AddScoped<ITodoRepo, TodoRepo>();
    }
}