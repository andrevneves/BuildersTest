using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Builders.DotNetCore.WebApi.Domain.Entities
{
    public class Node
    {
        [BsonId()]
        public string Id { get; set; }

        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
