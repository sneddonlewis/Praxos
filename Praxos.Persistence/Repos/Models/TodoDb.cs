using Dapper.Contrib.Extensions;

namespace Praxos.Application.Models;

[Table("Todo")]
public class TodoDb : DbEntity
{
    public string Item { get; set; }
}