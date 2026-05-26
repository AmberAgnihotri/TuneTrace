using ServiceLibrary.Services;
using Unit_Test_1.FakeRepositoriesExceptions;

namespace Unit_Test_1.ServiceExceptionTests
{
    [TestClass]
    public class SearchHistoryServiceExceptionTest
    {
        [TestMethod]
        public void SaveSearch_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new SearchHistoryService(new FakeRepositorySearchHistoryExceptions());

            // Act
            try
            {
                service.SaveSearch(1, "Taylor Swift");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while saving the search.", ex.Message);
            }
        }

        [TestMethod]
        public void GetRecentSearches_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new SearchHistoryService(new FakeRepositorySearchHistoryExceptions());

            // Act
            try
            {
                service.GetRecentSearches(1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while retrieving the recent searches.", ex.Message);
            }
        }
    }
}