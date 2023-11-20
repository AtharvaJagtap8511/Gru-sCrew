using ContosoCrafts.WebSite.Pages;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;


namespace UnitTests.Pages.Privacy

{

    /// <summary>

    /// Class that has unit test cases related to Privacy page

    /// </summary>

    public class PrivacyTests

    {

        // creating an instance

        #region TestSetup

        public static PrivacyModel pageModel;



        /// <summary>

        /// Initializing test

        /// </summary>

        [SetUp]

        public void TestInitialize()

        {

            var MockLoggerDirect = Mock.Of<ILogger<PrivacyModel>>();



            pageModel = new PrivacyModel(MockLoggerDirect)

            {

                PageContext = TestHelper.PageContext,

                TempData = TestHelper.TempData,

            };

        }



        #endregion TestSetup



        /// <summary>

        /// Test case to validate that on valid activity a valid RequestId is returned

        /// </summary>

        #region OnGet

        [Test]

        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()

        {

            // Arrange



            // Act

            pageModel.OnGet();



            // Reset



            // Assert

            Assert.AreEqual(true, pageModel.ModelState.IsValid);

        }

        #endregion OnGet

    }

}