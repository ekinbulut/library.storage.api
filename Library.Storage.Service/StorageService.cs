using System;
using System.Collections.Generic;
using System.Linq;
using Library.Storage.Service.Data.Entities;
using Library.Storage.Service.Data.Repositories;
using Library.Storage.Service.Requests;
using Library.Storage.Service.Responses;
using Library.Storage.Service.ServiceModels;

namespace Library.Storage.Service
{
    public class StorageService : IStorageService
    {
        private readonly IStorageRepository _storageRepository;

        public StorageService(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        public StorageServiceResponse SelectAll(int requestOffset, int requestLimit)
        {
            var storage = _storageRepository.SelectAll()?.Skip(requestOffset).Take(requestLimit);

            if (storage == null) return new StorageServiceResponse();

            return new StorageServiceResponse
                   {
                       Storages = storage.SelectMany(t => new List<StorageServiceModel>
                                                          {
                                                              new StorageServiceModel
                                                              {
                                                                  Id = t.Id, Name = t.Name, RackNumber = t.RackNumber
                                                              }
                                                          })
                   };
        }

        public StorageServiceResponse Select(string id)
        {
            var storage = _storageRepository.Select(id);

            if (storage == null) return new StorageServiceResponse();

            return new StorageServiceResponse
                   {
                       Storages = new List<StorageServiceModel>
                                  {
                                      new StorageServiceModel
                                      {
                                          Id = storage.Id, Name = storage.Name, RackNumber = storage.RackNumber
                                      }
                                  }
                   };
        }

        public void InsertStorage(InsertStorageServiceRequest request)
        {
            var entity = new EStorage
                         {
                             Name = request.Name, RackNumber = request.RackNumber, CreateDateTime = DateTime.Now
                             , UpdateDateTime = null
                         };
            _storageRepository.Insert(entity);
        }

        public void UpdateStorage(UpdateStorageServiceRequest request)
        {
            var entity = new EStorage
                         {
                             Id = request.Id, Name = request.Name, RackNumber = request.RackNumber
                             , UpdateDateTime = DateTime.Now
                         };

            _storageRepository.Update(entity);
        }

        public void DeleteStorage(string id)
        {
            _storageRepository.Delete(id);
        }
    }
}