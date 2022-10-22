using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Threading.Tasks;
using TodoListApp.Controllers;
using TodoListApp.Data;
using TodoListApp.Test.MockData;

namespace TodoListApp.Test.Controller
{
    public class TestTodoController
    {
        [Fact]
        public async Task GetAllAsync_ShouldReturn200Status()
        {
            /// Arrange
            var todoService = new Mock<IDataAccessProvider>();
            todoService.Setup(_ => _.GetAllAsync()).ReturnsAsync(TodoListMockData.GetTodos());
            var sut = new TodoListController(todoService.Object);

            /// Act
            var result = (OkObjectResult)await sut.GetAllAsync();


            // /// Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetPendings_ShouldReturn200Status()
        {
            /// Arrange
            var todoService = new Mock<IDataAccessProvider>();
            todoService.Setup(_ => _.GetPendingTasks()).ReturnsAsync(TodoListMockData.GetTodos());
            var sut = new TodoListController(todoService.Object);

            /// Act
            var result = (OkObjectResult)await sut.GetPendings();


            // /// Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetOverdues_ShouldReturn200Status()
        {
            /// Arrange
            var todoService = new Mock<IDataAccessProvider>();
            todoService.Setup(_ => _.GetOverdueTasks()).ReturnsAsync(TodoListMockData.GetTodos());
            var sut = new TodoListController(todoService.Object);

            /// Act
            var result = (OkObjectResult)await sut.GetOverdues();


            // /// Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturn204NoContentStatus()
        {
            /// Arrange
            var todoService = new Mock<IDataAccessProvider>();
            todoService.Setup(_ => _.GetAllAsync()).ReturnsAsync(TodoListMockData.GetEmptyTodos());
            var sut = new TodoListController(todoService.Object);

            /// Act
            var result = (NoContentResult)await sut.GetAllAsync();


            /// Assert
            result.StatusCode.Should().Be(204);
            todoService.Verify(_ => _.GetAllAsync(), Times.Exactly(1));
        }

        [Fact]
        public async Task SaveAsync_ShouldCall_ITodoService_SaveAsync_AtleastOnce()
        {
            /// Arrange
            var todoService = new Mock<IDataAccessProvider>();
            var newTodo = TodoListMockData.NewTodo();
            var sut = new TodoListController(todoService.Object);

            /// Act
            var result = await sut.Create(newTodo);

            /// Assert
            todoService.Verify(_ => _.SaveAsync(newTodo), Times.Exactly(1));
        }
    }
}
