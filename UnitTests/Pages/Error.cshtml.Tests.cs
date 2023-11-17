using ContosoCrafts.WebSite.Pages;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Diagnostics;

namespace UnitTests.Pages.Error
{
    /// <summary>
    /// Class containing unit test cases for the Error page
    /// </summary>
    public class ErrorTests
    {
        // Creating an instance

        #region TestSetup

        public static ErrorModel pageModel;

        /// <summary>
        /// Initializing test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // Code for initialization
            var MockLoggerDirect = Mock.Of<ILogger<ErrorModel>>();
            pageModel = new ErrorModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test case to validate that on valid activity, a valid RequestId is returned
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // Arrange
            Activity activity = new Activity("activity");
            activity.Start();

            // Act
            pageModel.OnGet();

            // Reset
            activity.Stop();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(activity.Id, pageModel.RequestId);
        }

        /// <summary>
        /// Test case to validate that on an invalid activity, TraceIdentifier returns a RequestId
        /// </summary>
        [Test]
        public void OnGet_InValid_Activity_Null_Should_Return_TraceIdentifier()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("trace", pageModel.RequestId);
            Assert.AreEqual(true, pageModel.ShowRequestId);
        }

        #endregion OnGet
    }
}