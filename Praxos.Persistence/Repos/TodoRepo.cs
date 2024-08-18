using System.Data.Common;
using Dapper;
using Dapper.Contrib.Extensions;
using Praxos.Application.Contracts.Persistence;
using Praxos.Application.Models;
using Praxos.Persistence.Models;
using Praxos.Persistence.Models.Mapping;

namespace Praxos.Persistence.Repos;

public class TodoRepo(string connectionString) : BaseRepo<Todo, TodoDb>(connectionString, Tables.Todo), ITodoRepo
{
}
