using Dapper.Contrib.Extensions;
using Praxos.Persistence.Models.BaseModels;

namespace Praxos.Persistence.Models;

[Table("Todo")]
public class TodoDb : DbEntity
{
    public string Item { get; set; }
}