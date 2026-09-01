using bookshelf.DbContexts;
using bookshelf.Models;
using Bookshelf.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Bookshelf.Tests.Controllers
{
    public class BooksControllerTests
    {
        // Создаём фейковую базу данных в памяти для тестов
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Уникальное имя для каждого теста
                .Options;

            return new AppDbContext(options);
        }

        // Тест 1: GET /api/books — возвращает все книги
        [Fact]
        public async Task GetBooks_ReturnsAllBooks_WhenNoGenreFilter()
        {
            // Arrange (подготовка)
            var context = GetInMemoryDbContext();
            context.Books.AddRange(
                new Book { Title = "Книга 1", Author = "Автор 1", Genre = "Роман", Year = 2000 },
                new Book { Title = "Книга 2", Author = "Автор 2", Genre = "Фантастика", Year = 2010 }
            );
            await context.SaveChangesAsync();

            var controller = new BooksController(context);

            // Act (действие)
            var result = await controller.GetBooks(null);

            // Assert (проверка)
            var okResult = Assert.IsType<ActionResult<IEnumerable<Book>>>(result);
            var books = Assert.IsAssignableFrom<IEnumerable<Book>>(okResult.Value);
            Assert.Equal(2, books.Count());
        }

        // Тест 2: GET /api/books?genre=роман — возвращает только романы
        [Fact]
        public async Task GetBooks_ReturnsOnlyBooksWithMatchingGenre()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            context.Books.AddRange(
                new Book { Title = "Роман 1", Author = "Автор 1", Genre = "Роман", Year = 2000 },
                new Book { Title = "Фантастика 1", Author = "Автор 2", Genre = "Фантастика", Year = 2010 }
            );
            await context.SaveChangesAsync();

            var controller = new BooksController(context);

            // Act
            var result = await controller.GetBooks("роман");

            // Assert
            var okResult = Assert.IsType<ActionResult<IEnumerable<Book>>>(result);
            var books = Assert.IsAssignableFrom<IEnumerable<Book>>(okResult.Value);
            Assert.Single(books);
            Assert.All(books, b => Assert.Equal("Роман", b.Genre));
        }

        // Тест 3: POST /api/books — добавляет книгу и возвращает 201
        [Fact]
        public async Task PostBook_AddsBookAndReturnsCreatedAtAction()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var controller = new BooksController(context);
            var newBook = new Book { Title = "Новая книга", Author = "Автор", Genre = "Роман", Year = 2023 };

            // Act
            var result = await controller.PostBook(newBook);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var createdBook = Assert.IsType<Book>(createdAtActionResult.Value);
            Assert.Equal("Новая книга", createdBook.Title);
            Assert.Equal(1, await context.Books.CountAsync()); // Проверяем, что книга добавилась в БД
        }
    }
}