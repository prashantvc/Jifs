using System.Threading.Tasks;
using NUnit.Framework;

namespace Jifs.Tests
{
    [TestFixture]
    public class JifContextTest
    {
        JifContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new JifContext();
        }

        [Test]
        public async Task GetDefault25TrendingItems()
        {
            var trends = await _context.GetTrendingAsync();

            Assert.IsNotNull(trends);
            Assert.AreEqual(25, trends.pagination.count);
        }

        [Test]
        public async Task GivenASearchQueryGetItems()
        {
            var results = await _context.SearchAsync("cat");
            Assert.IsNotNull(results);
        }

        [Test]
        public async Task GivenAEmptySearchQueryReturnNullObject()
        {
            var results = await _context.SearchAsync(string.Empty);
            Assert.IsNull(results);
        }

        [Test]
        public async Task GivenAnIdGetImageObject()
        {
            var image = await _context.GetImageByIdAsync("feqkVgjJpYtjy");
            Assert.IsNotNull(image);
        }

        [Test]
        public async Task GivenAnEmptyIdReturnNull()
        {
            var image = await _context.GetImageByIdAsync("");
            Assert.IsNull(image);
        }

    [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
    }
}
