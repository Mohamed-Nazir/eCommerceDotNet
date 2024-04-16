using EhodBoutiqueEnLigne.Models.ViewModels;
using System.Collections.Generic;
using EhodBoutiqueEnLigne.Models;
using EhodBoutiqueEnLigne.Models.Repositories;
using EhodBoutiqueEnLigne.Models.Services;
using Microsoft.Extensions.Localization;
using Moq;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace EhodBoutiqueEnLigne.Tests
    {
    public class ProductServiceTests
        {
        private readonly Mock<ICart> _mockCart;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IStringLocalizer<ProductService>> _mockLocalizer;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _mockCart = new Mock<ICart>();
            _mockProductRepository = new Mock<IProductRepository>();
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockLocalizer = new Mock<IStringLocalizer<ProductService>>();
            _mockLocalizer.Setup(l => l["MissingName"]).Returns(new LocalizedString("MissingName", "MissingName"));
            _mockLocalizer.Setup(l => l["MissingQuantity"]).Returns(new LocalizedString("MissingQuantity", "MissingQuantity"));
            _mockLocalizer.Setup(l => l["MissingPrice"]).Returns(new LocalizedString("MissingPrice", "MissingPrice"));
            _mockLocalizer.Setup(l => l["PriceNotANumber"]).Returns(new LocalizedString("PriceNotANumber", "PriceNotANumber"));
            _mockLocalizer.Setup(l => l["PriceNotGreaterThanZero"]).Returns(new LocalizedString("PriceNotGreaterThanZero", "PriceNotGreaterThanZero"));
            _mockLocalizer.Setup(l => l["StockNotGreaterThanZero"]).Returns(new LocalizedString("StockNotGreaterThanZero", "StockNotGreaterThanZero"));
            _mockLocalizer.Setup(l => l["StockNotAnInteger"]).Returns(new LocalizedString("StockNotAnInteger", "StockNotAnInteger"));

            _productService = new ProductService(_mockCart.Object, _mockProductRepository.Object, _mockOrderRepository.Object, _mockLocalizer.Object);
        }

        [Fact]
        public void SaveProduct_AllFieldsFilled_ShouldNotReturnErrorMessages()
        {
            // Arrange
            var productViewModel = new ProductViewModel
            {
                Name = "Test Product",
                Description = "Test Description",
                Price = "10,99",
                Stock = "5"
                // Assurez-vous de remplir tous les champs requis
            };

            // Act
            _productService.SaveProduct(productViewModel);
            var modelErrors = _productService.CheckProductModelErrors(productViewModel);

            // Assert
            Assert.Empty(modelErrors);
        }

        [Fact]
        public void SaveProduct_MissingName_ShouldReturnErrorMessage()
        {
            // Arrange
            var productViewModel = new ProductViewModel
            {
                Name=" ",
                Description = "Test Description",
                Price = "10,99",
                Stock = "5"
            };

            // Act
           _productService.SaveProduct(productViewModel);
            var modelErrors = _productService.CheckProductModelErrors(productViewModel);

            // Assert
            Assert.Contains("MissingName", modelErrors);
        }

        [Fact]
        public void SaveProduct_MissingStock_ShouldReturnErrorMessage()
        {
            // Arrange
            var productViewModel = new ProductViewModel
            {
                Name = "Test Name ",
                Description = "Test Description",
                Price = "10,99",
                Stock = ""
            };

            // Act
            _productService.SaveProduct(productViewModel);
            var modelErrors = _productService.CheckProductModelErrors(productViewModel);

            // Assert
            Assert.Contains("MissingQuantity", modelErrors);
        }

        [Fact]
        public void SaveProduct_StockNotAnInteger_ShouldReturnErrorMessage()
        {
            var productViewModel = new ProductViewModel
            {
                Name = "Test Name",
                Description = "Test Description",
                Price = "10,99",
                Stock = "1,3"
            };

            // Act
            _productService.SaveProduct(productViewModel);
            var modelErrors = _productService.CheckProductModelErrors(productViewModel);

            // Assert
            Assert.Contains("StockNotAnInteger", modelErrors);
        }

        [Fact]
        public void SaveProduct_StockNotGreaterThanZero_ShouldReturnErrorMessage()
        {
            // Arrange
            var productViewModel = new ProductViewModel
            {
                Name = "Test Name ",
                Description = "Test Description",
                Price = "10,99",
                Stock = "-1"
            };

            // Act
            _productService.SaveProduct(productViewModel);
            var modelErrors = _productService.CheckProductModelErrors(productViewModel);

            // Assert
            Assert.Contains("StockNotGreaterThanZero", modelErrors);
        }

        [Fact]
        public void SaveProduct_MissingPrice_ShouldReturnErrorMessage()
        {
            // Arrange
            var productViewModel = new ProductViewModel
            {
                Name = "Test Name ",
                Description = "Test Description",
                Price = " ",
                Stock = "1"
            };

            // Act
            _productService.SaveProduct(productViewModel);
            var modelErrors = _productService.CheckProductModelErrors(productViewModel);

            // Assert
            Assert.Contains("MissingPrice", modelErrors);
        }

        [Fact]
        public void SaveProduct_PriceNotANumber_ShouldReturnErrorMessage()
        {
            // Arrange
            var productViewModel = new ProductViewModel
            {
                Name = "Test Name ",
                Description = "Test Description",
                Price = "a",
                Stock = "1"
            };

            // Act
            _productService.SaveProduct(productViewModel);
            var modelErrors = _productService.CheckProductModelErrors(productViewModel);
            Assert.Contains("PriceNotANumber", modelErrors);
        }

        [Fact]
        public void SaveProduct_PriceNotGreaterThanZero_ShouldReturnErrorMessage()
        {
            // Arrange
            var productViewModel = new ProductViewModel
            {
                Name = "Test Name ",
                Description = "Test Description",
                Price = "0",
                Stock = "1"
            };

            // Act
            _productService.SaveProduct(productViewModel);
            var modelErrors = _productService.CheckProductModelErrors(productViewModel);

            // Assert
            Assert.Contains("PriceNotGreaterThanZero", modelErrors);
        }


        [Fact]
        public void ExampleMethod()
            {
            // Arrange

            // Act


            // Assert
            Assert.Equal(1, 1);
            }
        }

    }