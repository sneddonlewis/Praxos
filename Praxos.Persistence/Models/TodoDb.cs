using Dapper.Contrib.Extensions;
using Praxos.Persistence.Models.BaseModels;

namespace Praxos.Persistence.Models;

[Table(Tables.Todo)]
public class TodoDb : EntityDb
{
    public string Item { get; set; }
}