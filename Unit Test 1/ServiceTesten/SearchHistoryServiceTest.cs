using ServiceLibrary.Services;
using Unit_Test_1.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1.ServiceTesten
{
    [TestClass]
    public class SearchHistoryServiceTest
    {
        [TestMethod]
        public void GetRecentSearches_ReturnsSearches()
        {
            // Arrange
            var service = new SearchHistoryService(new FakeSearchHistoryRepository());
            // Act
            var result = service.GetRecentSearches(1);
            // Assert
            Assert.HasCount(2, result);
            Assert.AreEqual("Taylor Swift", result[0]);
        }

        [TestMethod]
        public void SaveSearch_DoesNotThrow()
        {
            // Arrange
            var service = new SearchHistoryService(new FakeSearchHistoryRepository());
            // Act & Assert
            service.SaveSearch(1, "Taylor Swift");
        }
    }
}