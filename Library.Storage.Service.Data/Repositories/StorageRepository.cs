using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Library.Storage.Service.Data.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.Storage.Service.Data.Repositories
{
    [ExcludeFromCodeCoverage]
    public class StorageRepository : IStorageRepository
    {
        private readonly string _collectionName = "Storage";
        private readonly IMongoDatabase _database;

        public StorageRepository(IMongoClient client)
        {
            _database = client.GetDatabase("LibraryOS");
        }

        public void Delete(string id)
        {
            var collection = _database.GetCollection<EStorage>(_collectionName);

            collection.DeleteOneAsync(x => x.Id.Equals(id));
        }

        public void Update(EStorage entity)
        {
            var collection = _database.GetCollection<EStorage>(_collectionName);

            collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions
            {
                IsUpsert = true
            });
        }

        public void Insert(EStorage entity)
        {
            var collection = _database.GetCollection<EStorage>(_collectionName);
            collection.InsertOne(entity);
        }

        public IEnumerable<EStorage> SelectAll()
        {
            return _database.GetCollection<EStorage>(_collectionName).Find(new BsonDocument()).ToListAsync()
                .Result;
        }

        public EStorage Select(string id)
        {
            return _database.GetCollection<EStorage>(_collectionName).Find(x => x.Id.Equals(id))
                .FirstOrDefaultAsync().Result;
        }
    }
}