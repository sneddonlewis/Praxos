using System.Data.Common;
using Dapper;
using Dapper.Contrib.Extensions;
using Praxos.Application.Contracts.Persistence;
using Praxos.Application.Models;
using Praxos.Persistence.Models.BaseModels;
using Praxos.Persistence.Models.Mapping;

namespace Praxos.Persistence.Repos;

public class BaseRepo<TDomain, TPersistence>(DbConnection connection, string table) : IBaseRepo<TDomain>
    where TDomain : Entity
    where TPersistence : DbEntity
{
    public async Task<IEnumerable<TDomain>> All()
    {
        await connection.OpenAsync();
        var pModels = await connection.QueryAsync<TPersistence>($"SELECT * FROM {table}");
        return RepoMapper.Mapper.Map<IEnumerable<TDomain>>(pModels);
    }

    public async Task<TDomain> Create(TDomain entity)
    {
        var dbEntity = RepoMapper.Mapper.Map<TPersistence>(entity);
        dbEntity = dbEntity.GenerateId();
        await connection.OpenAsync();
        await connection.InsertAsync(dbEntity);
        return RepoMapper.Mapper.Map<TDomain>(dbEntity);
    }
}