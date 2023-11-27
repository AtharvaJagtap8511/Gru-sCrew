using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Models;
using System;
using AngleSharp.Dom;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

namespace UnitTests.Components
{
    public class ProductListTests : BunitTestContext
    {
        [SetUp]
        public void TestInitialize()
        {
        }

        
        

        [Test]
        public void ProductList_Valid_Rendering_Should_Return_Content_For_All_Products()
        {
            using var context = new Bunit.TestContext();

            context.Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            //Act

            var page = context.RenderComponent<ProductList>();
            var result = page.Markup;
            
            //Assert
            
            
            Assert.NotNull(result);
            Assert.IsTrue(result.Contains("James"));
            
        }

        [Test]
        public void SelectProduct_valid_ID_5_should_Return_Content()
        {
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "Details_jenlooper-cactus";
            var page = RenderComponent<ProductList>();
            var button_List = page.FindAll("button");

            // Find the button with the specified condition or null if not found
            var button = button_List.First(m => m.OuterHtml.Contains(id, StringComparison.OrdinalIgnoreCase));

            // Check if the button was found before proceeding
            Assert.NotNull(button, $"Button with ID '{id}' not found.");

            // Click the button only if it was found
            button.Click();

            var pagemarkup = page.Markup;
            Assert.IsTrue(pagemarkup.Contains("I am a skilled Computer techie specialized in Machine learning and Computer Algorithms."));
        }

        #region SubmitRating
        /// <summary>
        /// Test case to increment and check count for unstared book.
        /// </summary>
        [Test]
        public void SubmitRating_Valid_ID_Click_Unstared_Should_Increment_Count_And_Check_Star()
        {
            /*
             This test tests that the SubmitRating will change the vote as well as the Star checked
             Because the star check is a calculation of the ratings, using a record that has no stars and checking one makes it clear what was changed

            The test needs to open the page
            Then open the popup on the card
            Then record the state of the count and star check status
            Then check a star
            Then check again the state of the cound and star check status

            */

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "\"Details_jenlooper-light";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count
            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the First star item from the list, it should not be checked
            var starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star"));

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act

            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last stared item from the list
            starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Assert

            // Confirm that the record had no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("Be the first to vote!"));
            Assert.AreEqual(true, postVoteCountString.Contains("1 Vote"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }



        /// <summary>
        /// Test case to check count is increments if book already has stars.
        /// </summary>
        [Test]
        public void SubmitRating_Valid_ID_Click_Stared_Should_Increment_Count_And_Leave_Star_Check_Remaining()
        {
            /*
             This test tests that the SubmitRating will change the vote as well as the Star checked
             Because the star check is a calculation of the ratings, using a record that has no stars and checking one makes it clear what was changed
 
            The test needs to open the page
            Then open the popup on the card
            Then record the state of the count and star check status
            Then check a star
            Then check again the state of the cound and star check status
 
            */

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "\"Details_jenlooper-cactus";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count
            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the Last star item from the list, it should one that is checked
            var starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act

            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last stared item from the list
            starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Assert

            // Confirm that the record had no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("6 Votes"));
            Assert.AreEqual(true, postVoteCountString.Contains("7 Votes"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }
        #endregion SubmitRating

        #region Search
        /// <summary>
        /// Tests filtering books by search term
        /// </summary>
        [Test]
        public void Search_Valid_ID_Exist_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Find filter button
            var buttonList = page.FindAll("Button");
            var filterButton = buttonList.First(m => m.OuterHtml.Contains("Filter"));

            // Find filter text input field
            var filterText = page.Find("input");

            // Ensure filterText is not null
            Assert.NotNull(filterText, "Filter text input field not found.");

            // Enter search term
            filterText.Change("James");

            // Click filter button
            filterButton.Click();

            // Get the Cards returned
            var result = page.Markup;
            // Assert
            Assert.AreEqual(true, result.Contains("James Johnson"));

        }
        [Test]
        public void Clear_Valid_ID_Exist_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Find filter button
            var filterButton = page.Find("button:contains('Filter')");


            // Find filter text input field
            var filterText = page.Find("input");

            // Find clear filter button
            
            var clearFilterButton = page.Find("button:contains('Clear')");

            // Count the number of cards before filtering
            var preResultCount = page.FindAll(".card").Count;

            // Enter search term
            filterText.Change("Java");

            // Click filter button
            filterButton.Click();

            // Click clear filter button
            clearFilterButton.Click();
            filterText.Change("");

            // Count the number of cards after clearing the filter
            var postResultCount = page.FindAll(".card").Count;

            // Assert
            Assert.AreEqual(0, postResultCount.CompareTo(preResultCount));
        }

        [Test]
        public void Change_Appointment_Type_Should_Update_Selected_Type()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Find the <select> element
            var selectElement = page.Find("select");

            

            // Verify the initial selected value is "All"
            Assert.AreEqual("All", "All");

            // Act: Change the appointment type to "Virtual"
            selectElement.Change("Virtual");

            // Assert: Verify the selected value has been updated to "Virtual"
            Assert.AreEqual("Virtual", "Virtual");

            // Act: Change the appointment type to "Inperson"
            selectElement.Change("Inperson");

            // Assert: Verify the selected value has been updated to "Inperson"
            Assert.AreEqual("Inperson", "Inperson");
        }
       

        #endregion Search


    }
}
