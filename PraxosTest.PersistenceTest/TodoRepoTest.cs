using System.Data.Common;
using Dapper;
using Microsoft.Data.Sqlite;
using Praxos.Application.Contracts.Persistence;
using Praxos.Application.Models;
using Praxos.Persistence.Repos;

namespace PraxosTest.PersistenceTest;

[TestClass]
public class TodoRepoTest
{
    private static readonly string _dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{nameof(TodoRepoTest)}.db");
    private static readonly string _connectionString = "Data Source=" + _dbPath;
    private static ITodoRepo _todoRepo;
    
    [ClassInitialize]
    public static async Task ClassInitialize(TestContext _)
    {
        _todoRepo = new TodoRepo(_connectionString);
    }
    
    [TestInitialize]
    public async Task TestInitialize()
    {
        string createTable = @"
            CREATE TABLE IF NOT EXISTS Todo (
            Id TEXT PRIMARY KEY,
            Item Text TEXT NOT NULL)";
        await using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();
        await connection.ExecuteAsync(createTable);
    }

    [TestCleanup]
    public async Task TestCleanup()
    {
        string dropTable = "DROP TABLE Todo";
        await using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();
        await connection.ExecuteAsync(dropTable);
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        File.Delete(_dbPath);
    }
    
    [TestMethod]
    public async Task Create_PersistsEntity()
    {
        // Arrange
        const string todoItem = "vacuum";
        var todo = new Todo(todoItem);
        
        // Act
        await _todoRepo.Create(todo);
        
        // Assert
        var todos = (await _todoRepo.All()).ToArray();
        Assert.AreEqual(1, todos.Length);
        Todo actual = todos.First();
        Assert.AreEqual(todoItem, actual.Item);
        Assert.IsFalse(string.IsNullOrEmpty(actual.Id));

        var found = (await _todoRepo.FindById(actual.Id)).First();
        Assert.AreEqual(actual.Id, found.Id);
        Assert.AreEqual(actual.Item, found.Item);

        var isDeleted = await _todoRepo.Delete(found.Id);
        Assert.IsTrue(isDeleted);
        Assert.AreEqual(0, (await _todoRepo.All()).Count());
    }
}