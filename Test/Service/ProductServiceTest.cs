using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Moq;
using Service.Services;
using Service.Validators;
using Xunit;

namespace Test.Service
{
    public class ProductServiceTest
    {
        [Fact]
        public void GetByIdTest()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = "Product Test",
                Description = "Product Description Test",
                FabricationDate = DateTime.Now,
                LimitDate = DateTime.Now.AddDays(15),
                ProviderCnpj = "12345678000100",
                ProviderDescription = "Provider Description Test",
            };

            var productRepositoryMock = new Mock<IBaseRepository<Product>>();
            productRepositoryMock.Setup(x => x.GetById(product.Id)).Returns(product);
            
            // Act
            var service = new ProductService(productRepositoryMock.Object);
            var result = service.GetById(product.Id);

            // Assert
            Assert.Equal(result.Id, product.Id);
            Assert.Equal(result.Name, product.Name);
            Assert.Equal(result.Description, product.Description);
        }

        [Fact]
        public void InsertDataTest()
        {
            // Arrange
            var product = new Product
            {
                Name = "Product Test",
                Description = "Product Description Test",
                FabricationDate = DateTime.Now,
                LimitDate = DateTime.Now.AddDays(15),
                ProviderCnpj = "12345678000100",
                ProviderDescription = "Provider Description Test",
            };

            var productRepositoryMock = new Mock<IBaseRepository<Product>>();
            productRepositoryMock.Setup(x => x.Insert(product)).Returns(product);

            // Act
            var service = new ProductService(productRepositoryMock.Object);
            var result = service.Add<ProductValidator>(product);

            // Assert
            Assert.Equal(result.Id, product.Id);
            Assert.Equal(result.Name, product.Name);
            Assert.Equal(result.Description, product.Description);
        }
    }
}