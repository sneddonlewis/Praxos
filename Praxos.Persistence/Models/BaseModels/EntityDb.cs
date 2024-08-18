using Dapper.Contrib.Extensions;

namespace Praxos.Persistence.Models.BaseModels;

public abstract class EntityDb
{
    [ExplicitKey]
    public string Id { get; set; }
};