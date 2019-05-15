using System.Collections.Generic;
using Library.Storage.Service.Data.Entities;

namespace Library.Storage.Service.Data.Repositories
{
    public interface IStorageRepository
    {
        void Delete(string id);
        void Update(EStorage entity);
        void Insert(EStorage entity);
        IEnumerable<EStorage> SelectAll();
        EStorage Select(string id);
    }
}