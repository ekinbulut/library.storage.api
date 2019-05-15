namespace Library.Storage.Service.Requests
{
    public class UpdateStorageServiceRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int[] RackNumber { get; set; }
    }
}