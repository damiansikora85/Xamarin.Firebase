using NUnit.Framework;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Plugin.Firebase.UnitTest.iOS
{
    [TestFixture]
    public class StorageTests
    {
        private Storage _firebaseStorage;

        [SetUp]
        public void Setup()
        {
            _firebaseStorage = new Storage();
        }

        [Test]
        public async Task CanListRootDirectory()
        {
            var files = await _firebaseStorage.ListFiles("/");
            Assert.IsNotEmpty(files);
        }

        [Test]
        public async Task CanListDirectory()
        {
            var files = await _firebaseStorage.ListFiles("/test");
            Assert.IsNotEmpty(files);
        }

        [Test]
        public async Task CanDownloadFileToMemory()
        {
            var data = await _firebaseStorage.DownloadFileToMemory("/sqlite20210719.db");
            Assert.Greater(data.Length, 0);
        }

        [Test]
        public async Task CanDownloadFileToLocal()
        {
            var path = await _firebaseStorage.DownloadFileToLocalStorage("/test/dashboard.json");
            Assert.IsTrue(System.IO.File.Exists(path));
        }

        [Test]
        public async Task CanUploadToFileFromByteArray()
        {
            var data = Encoding.ASCII.GetBytes("1234567890");
            var transferedBytes = await _firebaseStorage.UploadFile("/test.dat", data);
            Assert.AreEqual(data.Length, transferedBytes);
        }

        [Test]
        public async Task CanUploadToFileFromStream()
        {
            var data = Encoding.ASCII.GetBytes("1234567890");
            var stream = new MemoryStream(data);
            var transferedBytes = await _firebaseStorage.UploadFile("/test.dat", stream);
            Assert.AreEqual(stream.Length, transferedBytes);
        }

        [Test]
        public async Task CanUploadToFileFromlocalStorage()
        {
            var transferedBytes = await _firebaseStorage.UploadFile("/test.txt", "file:///android_asset/test.txt");
            Assert.AreEqual(10, transferedBytes);
        }
    }
}