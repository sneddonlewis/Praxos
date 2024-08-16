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
                var conn = new SqliteConnection(connectionString);
                conn.Open();
                string createTable = @"
                    CREATE TABLE IF NOT EXISTS Todos (
                    Id TEXT PRIMARY KEY,
                    Item Text TEXT NOT NULL)";
                conn.Execute(createTable); 
                return conn;
            })
            .AddScoped<ITodoRepo, TodoRepo>();
    }
}