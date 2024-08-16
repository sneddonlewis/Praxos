using Dapper.Contrib.Extensions;

namespace Praxos.Application.Models;

public abstract class Entity
{
    [ExplicitKey]
    public string Id { get; set; }
};