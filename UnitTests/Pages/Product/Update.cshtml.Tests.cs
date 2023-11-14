using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace UnitTests.Pages.Product.Update
{
    /// <summary>
    /// Class containing unit test cases for the Update page
    /// </summary>
    public class UpdateTests
    {
        // Creating an instance

        #region TestSetup

        public static UpdateModel pageModel;

        /// <summary>
        /// Test initialization before each test case is executed
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // Code for initialization
            pageModel = new UpdateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// Testing If On GET, it is returning all the product names
        /// </summary>
        #region OnGet

        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("jenlooper-cactus");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("James Johnson", pageModel.Product.Title);

            // Reset
            // This should remove the error added
            pageModel.ModelState.Clear();
        }

        /// <summary>
        /// Testing OnGet if it redirects to the Index page when a bogus id is passed
        /// </summary>
        [Test]
        public void OnGet_InValid_Id_Bogus_Should_Return_Products()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet("Bogus") as RedirectToPageResult;

            // Assert
            Assert.AreEqual("./Index", result.PageName);

            // Reset
            // This should remove the error we added
            pageModel.ModelState.Clear();
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
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange
            pageModel.OnGet("jenlooper-cactus");
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            // Capture the original value
            var originalMaker = pageModel.Product.Maker;

            // Act
            // Change the value to test and update
            pageModel.Product.Maker = "test";
            var result = pageModel.OnPost() as RedirectToPageResult;
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            // Reset it back
            pageModel.OnGet("jenlooper-cactus"); // Refresh the page model data
            pageModel.Product.Maker = originalMaker; // Reset to the original value
            result = pageModel.OnPost() as RedirectToPageResult;

            // Assert to see that post succeeded
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            // Assertions to verify
            Assert.AreEqual(originalMaker, pageModel.Product.Maker); // Ensure it is reset to the original value
        }



        /// <summary>
        /// Testing OnPost invalid should return bogus
        /// </summary>
        [Test]
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);

            // Reset
            // This should remove the error we added
            pageModel.ModelState.Clear();
        }


        #endregion OnPost

    }
}
