using System.Data.Common;
using Dapper;
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
            .AddScoped<DbConnection>(sp =>
            {
                using var connection = new SqliteConnection(connectionString);
                connection.Open();
                string createTable = @"
                    CREATE TABLE IF NOT EXISTS Todo (
                    Id TEXT PRIMARY KEY,
                    Item Text TEXT NOT NULL)";
                connection.Execute(createTable); 
                return connection;
            })
            .AddScoped<ITodoRepo>(sp => new TodoRepo(connectionString));
    }
}