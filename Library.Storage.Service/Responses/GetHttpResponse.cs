using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Library.Storage.Service.Responses
{
    [ExcludeFromCodeCoverage]
    public class GetHttpResponse
    {
        public int Total { get; set; }
        public IEnumerable<object> StorageCollection { get; set; }
    }
}