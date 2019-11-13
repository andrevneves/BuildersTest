using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Builders.DotNetCore.Domain.Entities;
using Builders.DotNetCore.Domain.Interfaces;
using Builders.DotNetCore.Domain.Interfaces.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Builders.DotNetCore.Infrastructure.Implementation
{
    public class NodeRepository : INodeRepository
    {
        IMongoClient Client = null;
        IMongoCollection<Node> Collection;
        IMongoDatabase Database;

        private void InitSet(string server, string databaseName, string collectionName)
        {
            Client = new MongoClient(server);
            Database = Client.GetDatabase(databaseName);
            Collection = Database.GetCollection<Node>(collectionName);
        }

        public NodeRepository(string server, string databaseName, string collectionName)
        {
            InitSet(server, databaseName, collectionName);
        }

        public NodeRepository(IConfiguration configuration)
        {
            var server = configuration.GetSection("MongoSettings").GetSection("Connection").Value;
            var databaseName = configuration.GetSection("MongoSettings").GetSection("DatabaseName").Value;
            var collectionName = configuration.GetSection("MongoSettings").GetSection("CollectionName").Value;
            InitSet(server, databaseName, collectionName);
        }

        public string Insert(Node entity)
        {
            entity.Id = Guid.NewGuid().ToString();

            Collection.InsertOne(entity);

            return entity.Id;
        }

        public bool Delete(string id)
        {
            return Collection.DeleteOne(t => t.Id == id).DeletedCount > 0;
        }

        public bool Exists(Expression<Func<Node, bool>> filter)
        {
            return Collection.Find(filter).CountDocuments() > 0;
        }

        public IList<Node> GetAll()
        {
            return Collection.Find(t => true).ToList<Node>();
        }

        public Node GetById(string id)
        {
            return Collection.Find(t => t.Id == id).FirstOrDefault<Node>();
        }

        public IList<Node> SearchFor(Expression<Func<Node, bool>> filter)
        {
            return Collection.Find(filter).ToList<Node>();
        }

        public bool Update(Node entity)
        {
            var filter = new BsonDocument("_id", entity.Id);
            var update = new BsonDocument("$set", new BsonDocument(entity.ToBsonDocument()));
            return Collection.UpdateOne(filter, update).ModifiedCount > 0;
        }

    }
}
