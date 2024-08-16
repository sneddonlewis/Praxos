using Dapper.Contrib.Extensions;
using Praxos.Application.Models;

namespace Praxos.Persistence.Repos;

[Table("Todo")]
public class TodoDb : DbEntity
{
    public string Item { get; set; }
}