using System;
using MongoDB.Driver;
using MongoDB.Bson;


namespace MongoDbConsoleFindDocs
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbClient = new MongoClient("mongodb://127.0.0.1:27017");

            IMongoDatabase db = dbClient.GetDatabase("MyDatabase");
            var res = db.GetCollection<BsonDocument>("Person");

            var filter = Builders<BsonDocument>.Filter.Eq("SiblingCount", 3);

            var doc = res.Find(filter).FirstOrDefault();
            Console.WriteLine(doc.ToString());

            Console.ReadKey();
        }
    }
}
