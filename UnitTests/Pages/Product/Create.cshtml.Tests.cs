using System.Linq;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Create
{
    /// <summary>
    /// Class containing unit test cases for the create page
    /// </summary>
    public class CreateTests
    {
        /// <summary>
        /// Creating an instance of the model
        /// </summary>
        #region TestSetup
        public static CreateModel pageModel;

        /// <summary>
        /// Initializing test context before each test method is executed
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // Code for initialization
            pageModel = new CreateModel(TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup

        /// <summary>
        /// Testing if OnGet is valid and it is returning all the product names
        /// </summary> 
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            var oldCount = TestHelper.ProductService.GetAllData().Count();

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(oldCount + 1, TestHelper.ProductService.GetAllData().Count());
        }
        #endregion OnGet
    }
}
