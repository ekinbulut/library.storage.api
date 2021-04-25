using System;
using System.Diagnostics.CodeAnalysis;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Library.Storage.Service.Data.Entities
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class EStorage
    {
        public EStorage()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonId] public string Id { get; set; }

        public string Name { get; set; }
        public int[] RackNumber { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
        public DateTime? UpdateDateTime { get; set; } = DateTime.Now;
    }
}