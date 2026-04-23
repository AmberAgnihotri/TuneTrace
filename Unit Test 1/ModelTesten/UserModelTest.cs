using ServiceLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1.ModelTesten
{
    [TestClass]
    public class UserModelTest
    {
        [TestMethod]
        public void UserModel_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var id = 1;
            var account = "amber";
            var favoriteSongIds = new List<int> { 1, 2 };
            var favoriteAlbumIds = new List<int> { 1 };
            var favoriteArtistIds = new List<int> { 1 };

            // Act
            var user = new UserModel(id, account, favoriteSongIds, favoriteAlbumIds, favoriteArtistIds);

            // Assert
            Assert.AreEqual(id, user.Id);
            Assert.AreEqual(account, user.Account);
            Assert.IsNotNull(user.FavoriteSongIds);
            Assert.IsNotNull(user.FavoriteAlbumIds);
            Assert.IsNotNull(user.FavoriteArtistIds);
            Assert.HasCount(2, user.FavoriteSongIds);
            Assert.HasCount(1, user.FavoriteAlbumIds);
            Assert.HasCount(1, user.FavoriteArtistIds);
        }
    }
}