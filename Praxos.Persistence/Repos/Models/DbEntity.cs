using Dapper.Contrib.Extensions;

namespace Praxos.Application.Models;

public abstract class DbEntity
{
    [ExplicitKey]
    public string Id { get; set; }
};