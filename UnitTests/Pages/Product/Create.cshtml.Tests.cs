using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitTests.Pages.Product.Create
{
    /// <summary>
    /// Class containing unit test cases of create page
    /// </summary>
    public class CreateTests
    {
        /// <summary>
        /// Creating insance of the model
        /// </summary>
        #region TestSetup
        private CreateModel pageModel;

        /// <summary>
        /// Initializing test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // Creating a new instance of CreateModel for each test
            pageModel = new CreateModel(TestHelper.ProductService);
        }
        #endregion TestSetup

        /// <summary>
        /// Testing If on get the it is returnig all the product names
        /// </summary> 
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("jenlooper-cactus");// Should return an ID

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(false, pageModel.Product.Id == "");
        }

        /// <summary>
        /// Testing If on get the it is initialize the product for null values
        /// </summary> 
        [Test]
        public void OnGet_With_Null_Product_Should_Initialize_Product()
        {
            // Arrange
            // Act
            pageModel.OnGet(null);

            // Assert
            Assert.IsNotNull(pageModel.Product);
        }

        #endregion OnGet

        /// <summary>
        /// Testing If On POST, it is returning all the product names
        /// </summary>
        #region OnPost

        [Test]
        /// <summary>
        /// Test that checks update functionality
        /// </summary>
        public void OnPost_With_Invalid_Model_Should_Return_Page()
        {
            // Arrange
            pageModel.ModelState.AddModelError("Product.Title", "Title is required");

            // Act
            var result = pageModel.OnPost() as PageResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(pageModel.ModelState.IsValid);
        }

        /// <summary>
        /// Testing OnPost redirects to index page
        /// </summary>
        [Test]
        public void OnPost_With_Valid_Model_Should_Return_RedirectToIndex()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "valid-id",
                Title = "valid-title",
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(pageModel.ModelState.IsValid);
            Assert.AreEqual("Index", result.PageName);
        }
        #endregion OnPost
    }
}