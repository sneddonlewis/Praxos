using AutoMapper;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using Praxos.Application.Contracts.Persistence;
using Praxos.Application.Models;
using Praxos.Persistence.Models.BaseModels;
using Praxos.Persistence.Models.Mapping;

namespace Praxos.Persistence.Repos;

public class BaseRepo<TDomain, TPersistence>(string connectionString, string table) : IBaseRepo<TDomain>
    where TDomain : Entity
    where TPersistence : EntityDb
{
    private readonly IMapper _mapper = RepoMapper.Mapper;
    
    public async Task<IEnumerable<TDomain>> All()
    {
        await using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();
        var pModels = await connection.QueryAsync<TPersistence>($"SELECT * FROM {table}");
        return _mapper.Map<IEnumerable<TDomain>>(pModels);
    }

    public async Task<TDomain> Create(TDomain entity)
    {
        await using var connection = new SqliteConnection(connectionString);
        var dbEntity = _mapper.Map<TPersistence>(entity);
        dbEntity = dbEntity.GenerateId();
        await connection.InsertAsync(dbEntity);
        return _mapper.Map<TDomain>(dbEntity);
    }

    public async Task<IEnumerable<TDomain>> FindById(string id)
    {
        await using var connection = new SqliteConnection(connectionString);
        string sql = $"SELECT * FROM {table} WHERE  Id = @Id";
        try
        {
            var result = await connection.QueryAsync<TPersistence>(sql, new { Id = id });
            return _mapper.Map<IEnumerable<TDomain>>(result);
        }
        catch
        {
            return [];        
        }
    }

    public async Task<bool> Delete(string id)
    {
        await using var connection = new SqliteConnection(connectionString);
        string sql = $"DELETE FROM {table} WHERE  Id = @Id";
        try
        {
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return true;
        }
        catch
        {
            return false;
        }
    }
}