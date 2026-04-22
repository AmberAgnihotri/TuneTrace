using DAL.Repositories;
using serviceLibary.Services;
using Unit_Test_1.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1.ServiceTesten
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void GetFavorites_ReturnsCorrectFavorites()
        {
            var service = new UserService(new FakeUserRepository());
            var result = service.GetFavorites(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.HasCount(2, result.FavoriteSongIds);
            Assert.HasCount(1, result.FavoriteAlbumIds);
            Assert.HasCount(1, result.FavoriteArtistIds);
        }

        [TestMethod]
        public void GetFavorites_ReturnsNull_WhenUserNotFound()
        {
            var service = new UserService(new FakeUserRepository());
            var result = service.GetFavorites(99);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void AddFavoriteSong_DoesNotThrow()
        {
            var service = new UserService(new FakeUserRepository());
            service.AddFavoriteSong(1, 1);
        }

        [TestMethod]
        public void RemoveFavoriteSong_DoesNotThrow()
        {
            var service = new UserService(new FakeUserRepository());
            service.RemoveFavoriteSong(1, 1);
        }

        [TestMethod]
        public void AddFavoriteAlbum_DoesNotThrow()
        {
            var service = new UserService(new FakeUserRepository());
            service.AddFavoriteAlbum(1, 1);
        }

        [TestMethod]
        public void RemoveFavoriteAlbum_DoesNotThrow()
        {
            var service = new UserService(new FakeUserRepository());
            service.RemoveFavoriteAlbum(1, 1);
        }

        [TestMethod]
        public void AddFavoriteArtist_DoesNotThrow()
        {
            var service = new UserService(new FakeUserRepository());
            service.AddFavoriteArtist(1, 1);
        }

        [TestMethod]
        public void RemoveFavoriteArtist_DoesNotThrow()
        {
            var service = new UserService(new FakeUserRepository());
            service.RemoveFavoriteArtist(1, 1);
        }

        [TestMethod]
        public void GetRecentSearches_ReturnsSearches()
        {
            var service = new UserService(new FakeUserRepository());
            var result = service.GetRecentSearches(1);
            Assert.HasCount(2, result);
            Assert.AreEqual("Taylor Swift", result[0]);
        }

        [TestMethod]
        public void SaveSearch_DoesNotThrow()
        {
            var service = new UserService(new FakeUserRepository());
            service.SaveSearch(1, "Taylor Swift");
        }
    }
}