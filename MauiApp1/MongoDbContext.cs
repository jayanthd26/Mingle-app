using MongoDB.Driver;

namespace MauiApp1;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<UserProfile> UserProfiles =>
        _database.GetCollection<UserProfile>("UserProfiles");
}