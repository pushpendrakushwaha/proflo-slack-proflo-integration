using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProfloSlackIntegration.Models;

namespace ProfloSlackIntegration.DataAccess
{
    public class PowerupDbContext
    {
        MongoClient mongoClient;
        IMongoDatabase database;

        public PowerupDbContext(IConfiguration configuration)
        {
            //mongoClient = new MongoClient(configuration.GetSection("MongoDB:server").Value);
            ////mongoClient = new MongoClient(Environment.GetEnvironmentVariable("mongo_db"));
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                mongoClient = new MongoClient(Environment.GetEnvironmentVariable("mongo_db"));
            }
            else
            {
                mongoClient = new MongoClient(configuration.GetSection("MongoDB:server").Value);
            }
            database = mongoClient.GetDatabase(configuration.GetSection("MongoDB:database").Value);
           
        }
        public IMongoCollection<ProfloSlackTeamBinding> ProfloSlackTeamBindings => database.GetCollection<ProfloSlackTeamBinding>("ProfloSlackTeamBindings");
        public IMongoCollection<Board> Boards => database.GetCollection<Board>("Boards");
        public IMongoCollection<List> Lists => database.GetCollection<List>("Lists");
        public IMongoCollection<Card> Cards => database.GetCollection<Card>("Cards");
        public IMongoCollection<SlackBindModel> SlackData => database.GetCollection<SlackBindModel>("SlackData");
    }
}
