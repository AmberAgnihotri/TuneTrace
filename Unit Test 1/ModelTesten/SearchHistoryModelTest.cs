using ServiceLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1.ModelTesten
{
    [TestClass]
    public class SearchHistoryModelTest
    {
        [TestMethod]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var date = new DateTime(2024, 1, 1);
            // Act
            var model = new SearchHistoryModel(1, 1, "Taylor Swift", date);
            // Assert
            Assert.AreEqual(1, model.Id);
            Assert.AreEqual(1, model.UserId);
            Assert.AreEqual("Taylor Swift", model.SearchTerm);
            Assert.AreEqual(date, model.SearchDate);
        }

        [TestMethod]
        public void SearchTerm_IsNotEmpty()
        {
            // Arrange
            var model = new SearchHistoryModel(1, 1, "Taylor Swift", DateTime.Now);
            // Act & Assert
            Assert.IsFalse(string.IsNullOrEmpty(model.SearchTerm));
        }

        [TestMethod]
        public void SearchDate_IsNotDefault()
        {
            // Arrange
            var model = new SearchHistoryModel(1, 1, "Taylor Swift", DateTime.Now);
            // Act & Assert
            Assert.AreNotEqual(default(DateTime), model.SearchDate);
        }
    }
}