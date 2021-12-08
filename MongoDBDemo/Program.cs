using MongoDataAccess.DataAccess;
using MongoDataAccess.Models;
using MongoDB.Driver;
using MongoDBDemo;

//string connectionString = "mongodb://127.0.0.1:27017";
//string databaseName = "simple_db";
//string collectionName = "people";

//var client = new MongoClient(connectionString);
//var db = client.GetDatabase(databaseName);
//var collection = db.GetCollection<PersonModel>(collectionName);

//var person = new PersonModel { FirstName = "Ana", LastName = "Helena" };
//await collection.InsertOneAsync(person);

//var results = await collection.FindAsync(_ => true);

//foreach (var result in results.ToList())
//{
//    Console.WriteLine($"{result.Id} {result.FirstName} {result.LastName}");
//}

ChoreDataAccess db = new ChoreDataAccess();

await db.CreateUserAsync(new UserModel { FirstName = "Ana", LastName = "Helena" });

var users = await db.GetAllUsersAsync();

var chore = new ChoreModel
{
    AssignedTo = users.FirstOrDefault(),
    ChoreText = "Mow the lawn",
    FrequencyInDays = 7,
};

await db.CreateChoreAsync(chore);

var chores = await db.GetAllChoresAsync();

var newChore = chores.First();
newChore.LastCompleted = DateTime.UtcNow;

await db.CompleteChoreAsync(newChore);