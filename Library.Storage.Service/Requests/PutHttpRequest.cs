using System.Diagnostics.CodeAnalysis;

namespace Library.Storage.Service.Requests
{
    [ExcludeFromCodeCoverage]
    public class PutHttpRequest
    {
        public string Name       { get; set; }
        public int[]  RackNumber { get; set; }
    }
}