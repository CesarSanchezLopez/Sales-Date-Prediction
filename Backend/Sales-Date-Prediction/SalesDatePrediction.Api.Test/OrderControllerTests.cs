using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Api.Controllers;  // Reemplaza con el espacio de nombres correcto
using SalesDatePrediction.Core.Interfaces;
using SalesDatePrediction.Core.Entities;      // Reemplaza con el espacio de nombres correcto
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApiProject.Tests
{
    public class OrderControllerTests
    {
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly OrderController _controller;

        public OrderControllerTests()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _controller = new OrderController(_mockOrderRepository.Object);
        }

        [Fact]
        public async Task GetCustId_ReturnsListOfOrders_WhenIdIsValid()
        {
            // Arrange
            var orderId = 1;
            var mockOrders = new List<Order>
            {
                new Order {  CustId = 1, OrderDate = DateTime.Now },
                new Order {  CustId = 1, OrderDate = DateTime.Now }
            };
            _mockOrderRepository.Setup(repo => repo.GetCustId(orderId)).ReturnsAsync(mockOrders);

            // Act
            var result = await _controller.GetCustId(orderId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<Order>>>(result);
            var returnValue = Assert.IsType<List<Order>>(actionResult.Value);
            Assert.Equal(2, returnValue.Count);  // Asegúrate de que el número de elementos sea correcto
        }

        [Fact]
        public async Task GetCustId_ReturnsNotFound_WhenNoOrdersFound()
        {
            // Arrange
            var orderId = 999;  // ID que no tiene órdenes asociadas
            _mockOrderRepository.Setup(repo => repo.GetCustId(orderId)).ReturnsAsync(new List<Order>());

            // Act
            var result = await _controller.GetCustId(orderId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<Order>>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);  // Esperamos un "NotFound" cuando no hay órdenes
        }

        [Fact]
        public async Task Post_ReturnsOrderId_WhenOrderIsPosted()
        {
            // Arrange
            var newOrder = new Order
            {
                CustId = 1,
                OrderDate = DateTime.Now
            };
            _mockOrderRepository.Setup(repo => repo.Post(newOrder)).ReturnsAsync(1);  // Supongamos que el ID del pedido es 1

            // Act
            var result = await _controller.Post(newOrder);

            // Assert
            var actionResult = Assert.IsType<ActionResult<int>>(result);
            var returnValue = Assert.IsType<int>(actionResult.Value);
            Assert.Equal(1, returnValue);  // Verifica que el valor retornado es el ID de la orden
        }
    }
}