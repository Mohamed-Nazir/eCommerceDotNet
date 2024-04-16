using EhodBoutiqueEnLigne.Models;
using EhodBoutiqueEnLigne.Models.Repositories;
using EhodBoutiqueEnLigne.Models.Services;
using EhodBoutiqueEnLigne.Models.ViewModels;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace EhodBoutiqueEnLigne.Tests
{
    public class OrderServiceTests
    {
        private readonly Mock<ICart> _mockCart;
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IProductService> _mockProductService;
        private readonly OrderService _orderService;

        public OrderServiceTests()
        {
            _mockCart = new Mock<ICart>();
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockProductService = new Mock<IProductService>();

            _orderService = new OrderService(_mockCart.Object, _mockOrderRepository.Object, _mockProductService.Object);
        }

        [Fact]
        public void SaveOrder_MissingName_ShouldReturnErrorMessage()
        {
            // Arrange
            var orderViewModel = new OrderViewModel
            {
                Address = "Parcelles Assainies",
                City = "Dakar",
                Zip = "10001",
                Country = "Senegal",
                Lines = new List<CartLine>()
            };

            // Act
            _orderService.SaveOrder(orderViewModel);
            var modelErrors = _orderService.CheckOrderModelErrors(orderViewModel);

            // Assert
            Assert.Contains("ErrorMissingName", modelErrors);
        }

        [Fact]
        public void SaveOrder_MissingAddress_ShouldReturnErrorMessage()
        {
            // Arrange
            var orderViewModel = new OrderViewModel
            {
                Name = "Moussa",
                City = "Dakar",
                Zip = "10001",
                Country = "Senegal",
                Lines = new List<CartLine>(), 
            };

            // Act
            _orderService.SaveOrder(orderViewModel);
            var modelErrors = _orderService.CheckOrderModelErrors(orderViewModel);

            // Assert
            Assert.Contains("ErrorMissingAddress", modelErrors);
        }

        [Fact]
        public void SaveOrder_MissingCity_ShouldReturnErrorMessage()
        {
            // Arrange
            var orderViewModel = new OrderViewModel
             {
                Name = "Moussa",
                City = "Dakar",
                Zip = "10001",
                Country = "Senegal",
                Lines = new List<CartLine>(), 
            };

            // Act
            _orderService.SaveOrder(orderViewModel);
            var modelErrors = _orderService.CheckOrderModelErrors(orderViewModel);

            // Assert
            Assert.Contains("ErrorMissingCity", modelErrors);
        }

        [Fact]
        public void SaveOrder_MissingZip_ShouldReturnErrorMessage()
        {
            // Arrange
            var orderViewModel = new OrderViewModel
             {
                Name = "Moussa",
                City = "Dakar",
                Zip = "10001",
                Country = "Senegal",
                Lines = new List<CartLine>(), 
            };

            // Act
            _orderService.SaveOrder(orderViewModel);
            var modelErrors = _orderService.CheckOrderModelErrors(orderViewModel);

            // Assert
            Assert.Contains("ErrorMissingZipCode", modelErrors);
        }

        [Fact]
        public void SaveOrder_MissingCountry_ShouldReturnErrorMessage()
        {
            // Arrange
            var orderViewModel = new OrderViewModel
             {
                Name = "Moussa",
                City = "Dakar",
                Zip = "10001",
                Country = "Senegal",
                Lines = new List<CartLine>(), 
            };
            // Act
            _orderService.SaveOrder(orderViewModel);
            var modelErrors = _orderService.CheckOrderModelErrors(orderViewModel);

            // Assert
            Assert.Contains("ErrorMissingCountry", modelErrors);
        }

        [Fact]
        public void CheckOrderModelErrors_AllFieldsFilled_ShouldReturnEmptyList()
        {
            // Arrange
            var orderViewModel = new OrderViewModel
            {
                Name = "Moussa",
                Address = "Keur Massar",
                City = "Dakar",
                Zip = "10001",
                Country = "Senegal",
                Lines = new List<CartLine>(), 
            };

            // Act
            var modelErrors = _orderService.CheckOrderModelErrors(orderViewModel);

            // Assert
            Assert.Empty(modelErrors);
        }
    }
}