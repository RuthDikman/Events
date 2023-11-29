using events;
using events.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests
{
    public class EventsControllerTests
    {
        private readonly EventsController _eventsController;
        public EventsControllerTests()
        { 
            var context=new DataContextFake();
            _eventsController = new EventsController(context);
        }
        [Fact]
        public void Get_ReturnOk()
        {
            var result = _eventsController.Get();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnNotFound()
        {
            //Arrange
            int id = 32;

            //Act
            var result = _eventsController.Get(id);

            //Assert
            Assert.IsType<NotFoundResult>(result);


        }
        [Fact]
        public void Post_IsCreated()
        {


            var eve = new Event { Id = 8, Title = "e8", Start = new DateTime(2023, 11, 7, 12, 30, 0), End = new DateTime(2023, 11, 8, 12, 30, 0) };

            // Act
            var result = _eventsController.Post(eve);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);


        }
        [Fact]
        public void Put_NoContent()
        {


            // Arrange
            var id = 1;
            var model = new Event { Title = "e111" };

            // Act
            var result = _eventsController.Put(id, model);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public void Delete_NoContent()
        {
            var id = 1;

            // Act
            var result = _eventsController.Delete(id);

            // Assert
            Assert.IsType<NoContentResult>(result);

        }
    }
}