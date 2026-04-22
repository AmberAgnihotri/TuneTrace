using DAL.Repositories;
using ServiceLibrary.Services;
using Unit_Test_1.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1.ServiceTesten
{
    [TestClass]
    public class SongServiceTest
    {
        [TestMethod]
        public void GetSongs_ReturnsAllSongs()
        {
            var service = new SongService(new FakeSongRepository());
            var result = service.GetSongs();
            Assert.HasCount(2, result);
        }

        [TestMethod]
        public void GetSongById_ReturnsCorrectSong()
        {
            var service = new SongService(new FakeSongRepository());
            var result = service.GetSongById(1);
            Assert.IsNotNull(result);
            Assert.AreEqual("Lavender Haze", result.Title);
            Assert.AreEqual("Taylor Swift", result.Artist);
        }

        [TestMethod]
        public void GetSongById_ReturnsNull_WhenNotFound()
        {
            var service = new SongService(new FakeSongRepository());
            var result = service.GetSongById(99);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SearchSongs_ReturnsResults()
        {
            var service = new SongService(new FakeSongRepository());
            var result = service.SearchSongs("Lavender");
            Assert.HasCount(1, result);
            Assert.AreEqual("Lavender Haze", result[0].Title);
        }

        [TestMethod]
        public void SearchSongs_ShortQuery_ThrowsException()
        {
            var service = new SongService(new FakeSongRepository());
            bool exceptionThrown = false;
            try { service.SearchSongs("a"); }
            catch (Exception) { exceptionThrown = true; }
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void AddFavorite_DoesNotThrow()
        {
            var service = new SongService(new FakeSongRepository());
            service.AddFavorite(1, 1);
        }

        [TestMethod]
        public void RemoveFavorite_DoesNotThrow()
        {
            var service = new SongService(new FakeSongRepository());
            service.RemoveFavorite(1, 1);
        }

        [TestMethod]
        public void AddRating_DoesNotThrow()
        {
            var service = new SongService(new FakeSongRepository());
            service.AddRating(1, 1, 8);
        }

        [TestMethod]
        public void AddReview_DoesNotThrow()
        {
            var service = new SongService(new FakeSongRepository());
            service.AddReview(1, 1, "Great song!");
        }
    }
}