using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SupportAppV3.Controllers;
using SupportAppV3.Mappings;
using SupportAppV3.Models;
using SupportAppV3.Repository;
using Xunit;

namespace SupportAppV3.Test
{
    public class TareasControllerTests
    {
        private readonly TareasController _controller;
        private readonly Mock<ITareaRepository> _mockTareaRepository;
        private readonly IMapper _mapper;

        public TareasControllerTests()
        {
            _mockTareaRepository = new Mock<ITareaRepository>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = config.CreateMapper();
            _controller = new TareasController(_mockTareaRepository.Object, _mapper);
        }

        [Fact]
        public async Task GetTareas_ReturnsOkResult()
        {
            // Arrange
            var tareas = new List<Tarea>
            {
                new Tarea { Id = 1, Nombre = "Tarea 1" }
            };
            _mockTareaRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(tareas);

            // Act
            var result = await _controller.GetTareas();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnTareas = Assert.IsType<List<Tarea>>(okResult.Value);
            Assert.Equal(1, returnTareas.Count);
        }
    }
}