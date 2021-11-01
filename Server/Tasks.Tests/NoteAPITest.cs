using Microsoft.EntityFrameworkCore;
using System;
using Tasks.API.Controllers;
using Tasks.DAL.Data;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Tasks.DAL.Repository;
using Tasks.DAL.Data.Interfaces;
using Tasks.Core.Model;

namespace Tasks.Tests
{
    public class NoteAPITest
    {
        private NoteController _controller;

        public NoteAPITest()
        {

            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "Tasks")
                .EnableSensitiveDataLogging()
                .Options;

            _controller = new NoteController(new DataContext(options));

        }

        [Theory]
        [InlineData(4)]
        public async void GetNotes_Test(int expected)
        {
            //Act
            var actual = await _controller.GetTasksAsync();

            //Assert
            Assert.Equal(expected, actual.Value.Count);
        }

        [Theory]
        [InlineData(1, 200)]
        public async void GetNote_Test(int expectedId, int expectedStatusCode)
        {
            //Act
            var actual = await _controller.GetTaskAsync(expectedId);
            var result = ((ObjectResult)actual.Result);

            //Assert
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }

        [Theory]
        [InlineData(-1, 400)]
        [InlineData(300, 400)]
        public async void GetNoteWithError_Test(int expectedId, int expectedStatusCode)
        {
            //Act
            var actual = await _controller.GetTaskAsync(expectedId);
            var result = ((BadRequestObjectResult)actual.Result);

            //Assert
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }

        [Fact]
        public async void PutNote_Test()
        {
            //Arrenge
            var expectedStatusCode = 200;

            //Act
            var updatedElement= await _controller.GetTaskAsync(1);
            var res = ((ObjectResult)updatedElement.Result);
            var noteObject = (Note)res.Value;
            noteObject.Title = "Test 1";
            var actual = await _controller.PutTasksAsync(noteObject);
            var result = ((OkResult)actual);

            //Assert
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }

    }
}
