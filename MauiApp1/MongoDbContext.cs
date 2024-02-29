using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;

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

    public IMongoCollection<User> usersCollection =>
    _database.GetCollection<User>("usersCollection");

    public async Task SaveSignUpDetails(string username, string email, string phoneNumber, string password)
    {
        var hashPass = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
        string hashPassString = BitConverter.ToString(hashPass).Replace("-", "").ToLower();

        var newUser = new User
        {
            Username = username,
            Email = email,
            PhoneNumber = phoneNumber,
            PasswordHash = hashPassString
        };

        await usersCollection.InsertOneAsync(newUser);
    }
}