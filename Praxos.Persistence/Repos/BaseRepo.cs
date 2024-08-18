using System.Data.Common;
using AutoMapper;
using Dapper;
using Dapper.Contrib.Extensions;
using Praxos.Application.Contracts.Persistence;
using Praxos.Application.Models;
using Praxos.Persistence.Models.BaseModels;
using Praxos.Persistence.Models.Mapping;

namespace Praxos.Persistence.Repos;

public class BaseRepo<TDomain, TPersistence>(DbConnection connection, string table) : IBaseRepo<TDomain>
    where TDomain : Entity
    where TPersistence : EntityDb
{
    private readonly IMapper _mapper = RepoMapper.Mapper;
    
    public async Task<IEnumerable<TDomain>> All()
    {
        await connection.OpenAsync();
        var pModels = await connection.QueryAsync<TPersistence>($"SELECT * FROM {table}");
        return _mapper.Map<IEnumerable<TDomain>>(pModels);
    }

    public async Task<TDomain> Create(TDomain entity)
    {
        var dbEntity = _mapper.Map<TPersistence>(entity);
        dbEntity = dbEntity.GenerateId();
        await connection.OpenAsync();
        await connection.InsertAsync(dbEntity);
        return _mapper.Map<TDomain>(dbEntity);
    }

    public async Task<IEnumerable<TDomain>> FindById(string id)
    {
        string sql = $"SELECT * FROM {table} WHERE  Id = @Id";
        try
        {
            var result = await connection.QueryAsync<TPersistence>(sql, new { Id = id });
            return _mapper.Map<IEnumerable<TDomain>>(result);
        }
        catch
        {
            return Enumerable.Empty<TDomain>();        
        }
    }
}