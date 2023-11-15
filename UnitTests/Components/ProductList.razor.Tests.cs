using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Bunit;
using AngleSharp.Dom;
using ContosoCrafts.WebSite.Services;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests.Components
{
    /// <summary>
    /// Test class initialized.
    /// </summary>
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup
        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("James Johnson"));
        }
        
    }
}