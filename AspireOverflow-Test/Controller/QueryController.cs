

using System.Linq;
using System.ComponentModel.DataAnnotations;
using AspireOverflow.Controllers;
using AspireOverflow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using AspireOverflow.DataAccessLayer.Interfaces;
using System;
using AspireOverflow.Services;
using AspireOverflow.CustomExceptions;

namespace AspireOverflowTest
{

    public class QueryControllerTest
    {
        private readonly QueryController _QueryController;
        private readonly Mock<ILogger<QueryController>> _logger = new Mock<ILogger<QueryController>>();
        private readonly Mock<IQueryService> _queryService = new Mock<IQueryService>();


        public QueryControllerTest()
        {
            _QueryController = new QueryController(_logger.Object, _queryService.Object);
        }

    


        [Theory]
        [InlineData(null)]
        public void AddSpam_ShouldReturnStatusCode400_WhenSpamObjectIsNull(Spam spam)
        {

            var Result = _QueryController.AddSpam(spam).Result as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);

        }

        [Fact]
        public void AddSpam_ShouldReturnStatusCode200_WhenSpamObjectIsPassed()
        {
            Spam spam = QueryMock.AddValidSpam();
            _queryService.Setup(obj => obj.AddSpam(spam)).Returns(true);

            var Result = _QueryController.AddSpam(spam).Result as ObjectResult;
            // Console.WriteLine(Result);
            Assert.Equal(200, Result?.StatusCode);

        }
        [Fact]
        public void AddSpam_ShouldReturnStatusCode400_WhenQueryServiceReturnsFalse()
        {
            var spam = new Spam();
            _queryService.Setup(obj => obj.AddSpam(spam)).Returns(false);

            var Result = _QueryController.AddSpam(spam).Result as ObjectResult;

            Assert.Equal(400, Result?.StatusCode);

        }
        
        [Fact]
        public void AddSpam_ShouldReturnStatusCode500_WhenValidationExceptionIsThrown()
        {
            var spam = new Spam();
            _queryService.Setup(obj => obj.AddSpam(spam)).Throws(new ValidationException());

            var Result = _QueryController.AddSpam(spam).Result as ObjectResult;

            Assert.Equal(500, Result?.StatusCode);
        }
       
        [Fact]
        public void AddSpam_ShouldReturnStatusCode500_WhenExceptionIsThrown()
        {
            var spam = new Spam();
            _queryService.Setup(obj => obj.AddSpam(spam)).Throws(new Exception());

            var Result = _QueryController.AddSpam(spam).Result as ObjectResult;

            Assert.Equal(400, Result?.StatusCode);
        }


        [Fact]
         public void GetListOfSpams_ShouldReturnListOfQueries_WhenMethodIsCalled()
        {
            var Spams=QueryMock.GetListOfSpams();
            

            _queryService.Setup(obj => obj.GetSpams(3)).Returns(Spams);

            var Result = _QueryController.GetListOfSpams().Result as ObjectResult;

            Assert.Equal(Spams, Result?.Value);
        }
        [Fact]
        public void GetListOfSpams_ShouldThrowStatusCode500_WhenExceptionIsThrown()
        {
            _queryService.Setup(obj => obj.GetSpams(3)).Throws(new Exception());

            var Result=_QueryController.GetListOfSpams().Result as ObjectResult;

            Assert.Equal(500,Result?.StatusCode);
        }


        [Theory]
        [InlineData(1,2)]
        public void  UpdateSpamStatus_ShouldChangeVerifyStatusId_WhenValidIdAndVerifyStatusID(int id, int VerifyStatusID)
        {
            var spam = QueryMock.GetListOfSpams().Where(item =>item.SpamId==id);

            _queryService.Setup(obj =>obj.ChangeSpamStatus(id,VerifyStatusID)).Returns(spam);

            var Result=_QueryController.UpdateSpamStatus(id,VerifyStatusID).Result as ObjectResult;

            Assert.Equal(spam, Result?.Value);
        }
    }
}
