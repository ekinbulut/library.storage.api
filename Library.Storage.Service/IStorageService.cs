using Library.Storage.Service.Requests;
using Library.Storage.Service.Responses;

namespace Library.Storage.Service
{
    public interface IStorageService
    {
        StorageServiceResponse SelectAll(int requestOffset, int requestLimit);
        StorageServiceResponse Select(string id);
        void InsertStorage(InsertStorageServiceRequest request);
        void UpdateStorage(UpdateStorageServiceRequest request);
        void DeleteStorage(string id);
    }
}