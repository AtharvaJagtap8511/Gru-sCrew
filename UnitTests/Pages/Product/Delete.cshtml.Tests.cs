using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Delete
{
    /// <summary>
    /// Class containing unit test cases for Delete page
    /// </summary>
    public class DeleteTests
    {
        /// <summary>
        /// Creating instance to the model
        /// </summary>
        #region TestSetup
        public static DeleteModel pageModel;

        /// <summary>
        /// Initializing test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DeleteModel(TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup

        /// <summary>
        /// Testing onGet valid should return all products
        /// </summary>

        [Test]

        public void OnGet_Valid_Should_Return_Products()

        {

            // Arrange



            // Act

            pageModel.OnGet("jenlooper-cactus");



            // Assert

            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual("James Johnson", pageModel.Product.Title);

        }



        /// <summary>
        /// Testing if OnGet returns products when bogus id is passed
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_InValid_Id_Bogus_Should_Return_Products()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet("Bogus") as RedirectToPageResult;

            // Assert
            Assert.AreEqual("./Index", result.PageName);
        }
        #endregion OnGet

        /// <summary>
        /// Testing OnPost valid should return all products
        /// </summary>

        /// <summary>

        ///  Testing If on POST the it is returnig all the product names

        /// </summary>

        #region OnPost

        [Test]

        public void OnPost_Valid_Should_Return_Products()

        {

            // Arrange

            pageModel.Product = new ProductModel

            {
                Id = "selinazawacki-moon",

                Title = "title",

                Description = "description",

                Url = "url",

                Image = "image"

            };



            // Act

            var result = pageModel.OnPost() as RedirectToPageResult;



            // Assert

            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual(true, result.PageName.Contains("Index"));

        }


        /// Testing onPost invalid should return bogus

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

        }

        #endregion OnPost

    }
}
