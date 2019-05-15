using System.Diagnostics.CodeAnalysis;

namespace Library.Storage.Service.Requests
{
    [ExcludeFromCodeCoverage]
    public class GetHttpRequest
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}