using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;



namespace UnitTests.Pages.Product.Update

{

    /// <summary>

    /// Class containing unit test cases to Update page

    /// </summary>

    public class UpdateTests

    {

        // creating an instance

        #region TestSetup

        public static UpdateModel pageModel;



        /// <summary>

        /// Test initialize before eache test case is executed

        /// </summary>

        [SetUp]

        public void TestInitialize()

        {
            //code for initialization

            pageModel = new UpdateModel(TestHelper.ProductService)

            {

            };

        }



        #endregion TestSetup



        /// <summary>

        /// Testing If on GET the it is returnig all the product names

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

        /// Testing OnGet if it redirects to Index page when a bogus id is passed

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

            // Reset
            // This should remove the error we added
            pageModel.ModelState.Clear();

        }



        /// <summary>

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

            // Reset
            // This should remove the error we added
            pageModel.ModelState.Clear();

        }

        #endregion OnPost

    }

}