using System.Data.Common;
using Dapper;
using Dapper.Contrib.Extensions;
using Praxos.Application.Contracts.Persistence;
using Praxos.Application.Models;
using Praxos.Persistence.Models;
using Praxos.Persistence.Models.Mapping;

namespace Praxos.Persistence.Repos;

public class TodoRepo(DbConnection conn) : ITodoRepo
{
    public async Task<IEnumerable<Todo>> All()
    {
        await conn.OpenAsync();
        var dbModels = await conn.QueryAsync<TodoDb>("SELECT * FROM Todo");
        // .Select(t => t.MapToDomain());
        return RepoMapper.Mapper.Map<IEnumerable<Todo>>(dbModels);
    }

    public async Task<Todo> Create(Todo entity)
    {
        var dbEntity = entity.MapToDb();
        dbEntity = dbEntity.GenerateId();
        await conn.OpenAsync();
        await conn.InsertAsync(dbEntity);
        return dbEntity.MapToDomain();
    }
}