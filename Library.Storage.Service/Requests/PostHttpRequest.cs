using System.Diagnostics.CodeAnalysis;

namespace Library.Storage.Service.Requests
{
    [ExcludeFromCodeCoverage]
    public class PostHttpRequest
    {
        public string Name { get; set; }
        public int[] RackNumber { get; set; }
    }
}