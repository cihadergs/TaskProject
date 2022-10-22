using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Data;
using TodoListApp.Providers;
using TodoListApp.Test.MockData;

namespace TodoListApp.Test.Service
{
    public class TestTodoService : IDisposable
    {
        private readonly DataContext _context;

        public TestTodoService()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new DataContext(options);

            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAllAsync_ReturnTodoCollection()
        {
            /// Arrange
            _context.datas.AddRange(TodoListMockData.GetTodos());
            _context.SaveChanges();

            var sut = new DataAccessProvider(_context);

            /// Act
            var result = await sut.GetAllAsync();

            /// Assert
            result.Should().HaveCount(TodoListMockData.GetTodos().Count);
        }

        [Fact]
        public async Task GetPendings_ReturnTodoCollection()
        {
            /// Arrange
            _context.datas.AddRange(TodoListMockData.GetTodos());
            _context.SaveChanges();

            var sut = new DataAccessProvider(_context);

            /// Act
            var result = await sut.GetPendingTasks();

            /// Assert
            result.Should().HaveCount(TodoListMockData.GetTodos().Count);
        }

        [Fact]
        public async Task GetOverdue_ReturnTodoCollection()
        {
            /// Arrange
            _context.datas.AddRange(TodoListMockData.GetTodos());
            _context.SaveChanges();

            var sut = new DataAccessProvider(_context);

            /// Act
            var result = await sut.GetOverdueTasks();

            /// Assert
            result.Should().HaveCount(TodoListMockData.GetTodos().Count);
        }


        [Fact]
        public async Task SaveAsync_AddNewTodo()
        {
            /// Arrange
            var newTodo = TodoListMockData.NewTodo();
            _context.datas.AddRange(TodoListMockData.GetTodos());
            _context.SaveChanges();

            var sut = new DataAccessProvider(_context);

            /// Act
            await sut.SaveAsync(newTodo);

            ///Assert
            int expectedRecordCount = (TodoListMockData.GetTodos().Count() + 1);
            _context.datas.Count().Should().Be(expectedRecordCount);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
