using System.Data.Common;
using Dapper;
using Dapper.Contrib.Extensions;
using Praxos.Application.Contracts.Persistence;
using Praxos.Application.Models;

namespace Praxos.Persistence.Repos;

public class TodoRepo(DbConnection conn) : ITodoRepo
{
    public async Task<IEnumerable<Application.Models.Todo>> All()
    {
        await conn.OpenAsync();
        return await conn.QueryAsync<Todo>("SELECT * FROM Todo");
    }

    public async Task<Todo> Create(Todo entity)
    {
        var dbEntity = new TodoDb()
        {
            Item = entity.Item,
        };
        dbEntity = dbEntity.GenerateId();
        await conn.OpenAsync();
        await conn.InsertAsync(dbEntity);
        entity.Id = dbEntity.Id;
        return entity;
    }
}