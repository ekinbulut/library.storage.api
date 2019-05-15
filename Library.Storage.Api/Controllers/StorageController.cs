using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using Library.Storage.Service;
using Library.Storage.Service.Requests;
using Library.Storage.Service.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Library.Storage.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/storage")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(GetHttpResponse), (int) HttpStatusCode.OK)]
        public IActionResult Get([FromQuery] GetHttpRequest request)
        {
            var serviceResponse = _storageService.SelectAll(request.Offset, request.Limit);

            var response = new GetHttpResponse
                           {
                               Total = serviceResponse.Total, StorageCollection = serviceResponse.Storages.SelectMany(
                                   storage => new List<object>
                                              {
                                                  new
                                                  {
                                                      storage.Id, storage.Name, storage.RackNumber
                                                  }
                                              })
                           };

            return StatusCode((int) HttpStatusCode.OK, response);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetHttpResponse), (int) HttpStatusCode.OK)]
        public IActionResult Get([FromRoute] string id)
        {
            var serviceResponse = _storageService.Select(id);

            var response = new GetHttpResponse
                           {
                               Total = serviceResponse.Total, StorageCollection = serviceResponse.Storages.SelectMany(
                                   storage => new List<object>
                                              {
                                                  new
                                                  {
                                                      storage.Id, storage.Name, storage.RackNumber
                                                  }
                                              })
                           };

            return StatusCode((int) HttpStatusCode.OK, response);
        }


        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.Created)]
        public IActionResult Post([FromBody] PostHttpRequest request)
        {
            _storageService.InsertStorage(new InsertStorageServiceRequest
                                          {
                                              Name = request.Name, RackNumber = request.RackNumber
                                          });


            return StatusCode((int) HttpStatusCode.Created);
        }


        [HttpPut("{id}")]
        [ProducesResponseType((int) HttpStatusCode.Accepted)]
        public IActionResult Put([FromRoute] string id, [FromBody] PutHttpRequest request)
        {
            _storageService.UpdateStorage(new UpdateStorageServiceRequest
                                          {
                                              Id = id, Name = request.Name, RackNumber = request.RackNumber
                                          });

            return StatusCode((int) HttpStatusCode.Accepted);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public IActionResult Delete([FromRoute] string id)
        {
            _storageService.DeleteStorage(id);

            return StatusCode((int) HttpStatusCode.OK);
        }
    }
}