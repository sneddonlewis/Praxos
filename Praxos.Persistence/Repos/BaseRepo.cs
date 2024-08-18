using System.Data.Common;
using Dapper;
using Praxos.Application.Contracts.Persistence;
using Praxos.Application.Models;
using Praxos.Persistence.Models.Mapping;

namespace Praxos.Persistence.Repos;

public class BaseRepo<TDomain, TPersistence>(DbConnection connection, string table) : IBaseRepo<TDomain> where TDomain : Entity
{
    public async Task<IEnumerable<TDomain>> All()
    {
        await connection.OpenAsync();
        var pModels = await connection.QueryAsync<TPersistence>($"SELECT * FROM {table}");
        return RepoMapper.Mapper.Map<IEnumerable<TDomain>>(pModels);
    }

    public Task<TDomain> Create(TDomain entity)
    {
        throw new NotImplementedException();
    }
}