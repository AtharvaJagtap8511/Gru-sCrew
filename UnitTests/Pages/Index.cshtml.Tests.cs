using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

using System.Linq;


using ContosoCrafts.WebSite.Pages;

 

namespace UnitTests.Pages.Index

{

    /// <summary>

    /// Class containing unit test cases of Index page

    /// </summary>

    public class IndexTests

    {

        // creating an instance

        #region TestSetup

        public static IndexModel pageModel;



        /// <summary>

        /// Initializing

        /// ILogger to write log messages

        /// </summary>

        [SetUp]

        public void TestInitialize()

        {

            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();



            pageModel = new IndexModel(MockLoggerDirect, TestHelper.ProductService)

            {

            };

        }



        #endregion TestSetup

        /// <summary>

        /// Test to validate onget method.

        /// Returns Products if valid.

        /// </summary>

        #region OnGet

        [Test]

        public void OnGet_Valid_Should_Return_Products()

        {

            // Arrange



            // Act

            pageModel.OnGet();



            // Assert

            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual(true, pageModel.Products.ToList().Any());

        }

        #endregion OnGet

    }

}