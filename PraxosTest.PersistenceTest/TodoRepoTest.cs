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
    private static DbConnection _connection;
    private static ITodoRepo _todoRepo;
    
    [ClassInitialize]
    public static async Task ClassInitialize(TestContext _)
    {
        _connection = new SqliteConnection(_connectionString);
        _todoRepo = new TodoRepo(_connection);
    }
    
    [TestInitialize]
    public async Task TestInitialize()
    {
        string createTable = @"
            CREATE TABLE IF NOT EXISTS Todo (
            Id TEXT PRIMARY KEY,
            Item Text TEXT NOT NULL)";
        await _connection.OpenAsync();
        await _connection.ExecuteAsync(createTable);
    }

    [TestCleanup]
    public async Task TestCleanup()
    {
        string dropTable = "DROP TABLE Todo";
        await _connection.OpenAsync();
        await _connection.ExecuteAsync(dropTable);
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
    }
}