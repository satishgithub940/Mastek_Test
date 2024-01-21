using Mastek.Model.Common;
using Mastek.Model.PostCode;
using Mastek_Test.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PostCode.Services.PostCode;

namespace Tastek_NUnitTest
{
    public class Tests
    {
        public static PostCodeDbo PostCodeDetail = null;
        [SetUp]
        public void Setup()
        {
            PostCodeDetail = new PostCodeDbo()
            {
                Country = "England",
                Region = "South East",
                AdminDistrict = "Waverley",
                ParliamentaryConstituency = "South West Surrey",
                Area = "South East Coast"
            };

        }

        [Test]
        public void GetAreaByPostCode_ValidPostCode_ReturnsOkResult()
        {
            // Arrange
            var mockPostCodeService = new Mock<IPostCodeService>();
            mockPostCodeService.Setup(x => x.GetAreaDetailByPostCode(It.IsAny<string>())).Returns(PostCodeDetail);
            var controller = new PostCodeController(mockPostCodeService.Object);
            // Act
            IActionResult result = controller.GetAreaByPostCode("ValidPostCode");

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetAreaByPostCode_InvalidPostCode_ReturnsBadRequestResult()
        {
            // Arrange
            var mockPostCodeService = new Mock<IPostCodeService>();
            var controller = new PostCodeController(mockPostCodeService.Object);

            // Act
            IActionResult result = controller.GetAreaByPostCode(string.Empty);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult.Value);
            Assert.AreEqual(Constants.Msg_InvalidpostCode, (okResult.Value as ErrorResponse).Message);
        }

        [Test]
        public void GetAreaByPostCode_PostCodeNotFound_ReturnsNotFoundResult()
        {
            PostCodeDetail = null;
            // Arrange
            var mockPostCodeService = new Mock<IPostCodeService>();
            mockPostCodeService.Setup(x => x.GetAreaDetailByPostCode(It.IsAny<string>())).Returns((PostCodeDetail));

            var controller = new PostCodeController(mockPostCodeService.Object);

            // Act
            IActionResult result = controller.GetAreaByPostCode("NonexistentPostCode");

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult.Value);
            Assert.AreEqual(Constants.Msg_PostCodeNotFound, (okResult.Value as ErrorResponse).Message);
        }
    }
}
