namespace Praxos.Application.Models;

public record Todo(string Item, string Id = "") : Entity(Id);