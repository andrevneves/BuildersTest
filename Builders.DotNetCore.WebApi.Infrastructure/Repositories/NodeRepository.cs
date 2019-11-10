using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Builders.DotNetCore.WebApi.Domain.Entities;
using Builders.DotNetCore.WebApi.Domain.Interfaces;
using Builders.DotNetCore.WebApi.Domain.Interfaces.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Builders.DotNetCore.WebApi.Infrastructure.Implementation
{
    public class NodeRepository : INodeRepository
    {
        readonly IMongoClient Client = null;
        readonly string collectionName = "binary_tree";
        readonly IMongoCollection<Node> Collection;
        readonly IMongoDatabase Database;

        public NodeRepository(string databaseName = "builders")
        {
            Client = new MongoClient("mongodb://localhost");
            Database = Client.GetDatabase(databaseName);
            Collection = Database.GetCollection<Node>(collectionName);
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
