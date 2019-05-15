using System;
using System.Collections.Generic;
using System.Linq;
using Library.Storage.Service.Data.Entities;
using Library.Storage.Service.Data.Repositories;
using Library.Storage.Service.Requests;
using Moq;
using Xunit;

namespace Library.Storage.Service.Tests.StorageServiceTests
{
    public class StorageServiceTest
    {
        public StorageServiceTest()
        {
            _storageRepositoryMock = new Mock<IStorageRepository>();
        }

        private readonly Mock<IStorageRepository> _storageRepositoryMock;
        private StorageService _sut;

        [Fact]
        public void Select_WhenStorageRepository_ReturnsNull_ObjectShouldNotBeEmpty()
        {
            _storageRepositoryMock.Setup(t => t.SelectAll()).Returns(() => null);

            _sut = new StorageService(_storageRepositoryMock.Object);

            var actual = _sut.Select(Guid.NewGuid().ToString());

            Assert.NotNull(actual.Storages);
        }

        [Fact]
        public void Select_WhenStorageRepository_ReturnsWithData_ObjectShouldNotBeEmpty()
        {
            _storageRepositoryMock.Setup(t => t.Select(It.IsAny<string>())).Returns(() => new EStorage()
                                                                                          {
                                                                                              Id = "Id",
                                                                                              Name = "name",
                                                                                              RackNumber = null,
                                                                                              CreateDateTime = DateTime.Now
                                                                                          });

            _sut = new StorageService(_storageRepositoryMock.Object);

            var actual = _sut.Select(Guid.NewGuid().ToString());

            var storageServiceModel = actual.Storages.FirstOrDefault();

            Assert.NotNull(actual.Storages);
            Assert.Equal(1, actual.Total);
            Assert.Equal("Id", storageServiceModel.Id);
            Assert.Equal("name", storageServiceModel.Name);
            Assert.Null(storageServiceModel.RackNumber);

        }

        [Fact]
        public void When_DeleteStorage_Completed_VerifyStorageRepository()
        {
            _sut = new StorageService(_storageRepositoryMock.Object);
            _sut.DeleteStorage(Guid.NewGuid().ToString());
            _storageRepositoryMock.Verify(t => t.Delete(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void When_InsertStorage_Completed_VerifyStorageRepository()
        {
            _sut = new StorageService(_storageRepositoryMock.Object);
            _sut.InsertStorage(new InsertStorageServiceRequest()
                               {
                                   Name = "name",
                                   RackNumber = new int[]{1,2,3}
                               });
            _storageRepositoryMock.Verify(t => t.Insert(It.IsAny<EStorage>()), Times.Once);
        }

        [Fact]
        public void WhenStorageRepository_ReturnsNull_ObjectShouldNotBeEmpty()
        {
            _storageRepositoryMock.Setup(t => t.SelectAll()).Returns(() => null);

            _sut = new StorageService(_storageRepositoryMock.Object);

            var actual = _sut.SelectAll(0, 10);

            Assert.NotNull(actual.Storages);
        }

        [Fact]
        public void WhenStorageRepository_ReturnsWithData_ObjectShouldNotBeEmpty()
        {
            _storageRepositoryMock.Setup(t => t.SelectAll()).Returns(() => new List<EStorage>
                                                                           {
                                                                               new EStorage()
                                                                           });

            _sut = new StorageService(_storageRepositoryMock.Object);

            var actual = _sut.SelectAll(0, 10);

            Assert.NotNull(actual.Storages);
            Assert.Equal(1, actual.Total);
        }

        [Fact]
        public void WhenUpdateStorage_Completed_VerifyStorageRepository()
        {
            _sut = new StorageService(_storageRepositoryMock.Object);
            _sut.UpdateStorage(new UpdateStorageServiceRequest()
                               {
                                   Id = "id",
                                   Name = "name",
                                   RackNumber = new int[]{1,2,3}
                               });
            _storageRepositoryMock.Verify(t => t.Update(It.IsAny<EStorage>()), Times.Once);
        }
    }
}