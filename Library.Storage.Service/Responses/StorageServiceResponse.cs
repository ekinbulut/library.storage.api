using System.Collections.Generic;
using System.Linq;
using Library.Storage.Service.ServiceModels;

namespace Library.Storage.Service.Responses
{
    public class StorageServiceResponse
    {
        public IEnumerable<StorageServiceModel> Storages { get; set; } = new List<StorageServiceModel>();

        public int Total => Storages.Count();
    }
}