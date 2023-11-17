using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Index
{
    /// <summary>
    /// Class containing unit test cases for the Index page
    /// </summary>
    public class IndexTests
    {
        // Creating an instance
        #region TestSetup
        public static PageContext pageContext;

        /// <summary>
        /// Creating an instance
        /// </summary>
        public static IndexModel pageModel;

        /// <summary>
        /// Test initialization before each test case is executed
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // Code for initialization
            pageModel = new IndexModel(TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup

        /// <summary>
        /// On making a GET call, the request should return all the products
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