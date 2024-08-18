using Praxos.Application.Contracts.Persistence;
using Praxos.Application.Models;
using Praxos.Persistence.Models;

namespace Praxos.Persistence.Repos;

public class TodoRepo(string connectionString) : BaseRepo<Todo, TodoDb>(connectionString, Tables.Todo), ITodoRepo {}
