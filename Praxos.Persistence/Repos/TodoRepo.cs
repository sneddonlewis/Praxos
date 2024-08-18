using System.Data.Common;
using Dapper;
using Dapper.Contrib.Extensions;
using Praxos.Application.Contracts.Persistence;
using Praxos.Application.Models;
using Praxos.Persistence.Models;
using Praxos.Persistence.Models.Mapping;

namespace Praxos.Persistence.Repos;

public class TodoRepo(DbConnection conn) : BaseRepo<Todo, TodoDb>(conn, "Todo"), ITodoRepo
{
    private readonly DbConnection _conn = conn;
    //
    // public async Task<IEnumerable<Todo>> All()
    // {
    //     await _conn.OpenAsync();
    //     var dbModels = await _conn.QueryAsync<TodoDb>("SELECT * FROM Todo");
    //     // .Select(t => t.MapToDomain());
    //     return RepoMapper.Mapper.Map<IEnumerable<Todo>>(dbModels);
    // }
    //
    // public async Task<Todo> Create(Todo entity)
    // {
    //     var dbEntity = entity.MapToDb();
    //     dbEntity = dbEntity.GenerateId();
    //     await _conn.OpenAsync();
    //     await _conn.InsertAsync(dbEntity);
    //     return dbEntity.MapToDomain();
    // }
}