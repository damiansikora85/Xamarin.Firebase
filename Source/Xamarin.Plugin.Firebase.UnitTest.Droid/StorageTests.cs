using Android.Content;
using Android.Content.Res;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Plugin.Firebase.UnitTest.Droid
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
            var data = await _firebaseStorage.DownloadFileToMemory("/firebase.png");
            Assert.Greater(data.Length, 0);
        }

        [Test]
        public async Task CanDownloadFileToLocal()
        {
            var path = await _firebaseStorage.DownloadFileToLocalStorage("/test/test.txt");
            Assert.IsTrue(System.IO.File.Exists(path));
        }

        [Test]
        public async Task CanUploadToFileFromByteArray()
        {
            var data = Encoding.ASCII.GetBytes("1234567890");
            var transferedBytes = await _firebaseStorage.UploadFile("/test.dat", data);
            Assert.AreEqual(data.Length, transferedBytes);
            await _firebaseStorage.DeleteFile("/test.dat");
        }

        [Test]
        public async Task CanUploadToFileFromStream()
        {
            var data = Encoding.ASCII.GetBytes("1234567890");
            var stream = new MemoryStream(data);
            var transferedBytes = await _firebaseStorage.UploadFile("/test.dat", stream);
            Assert.AreEqual(stream.Length, transferedBytes);
            await _firebaseStorage.DeleteFile("/test.dat");
        }

        [Test]
        [Ignore("to do")]
        public async Task CanUploadToFileFromlocalStorage()
        {
            var transferedBytes = await _firebaseStorage.UploadFile("/test.txt", "file:///android_asset/test.txt");
            Assert.AreEqual(10, transferedBytes);
        }

        [Test]
        public async Task CanDeleteFile()
        {
            var data = Encoding.ASCII.GetBytes("1234567890");
            var stream = new MemoryStream(data);
            var transferedBytes = await _firebaseStorage.UploadFile("/test.dat", stream);
            var files = await _firebaseStorage.ListFiles("/");
            var fileList = files.ToList();
            Assert.IsNotNull(fileList.FirstOrDefault(file => file.Filename == "test.dat"));
            await _firebaseStorage.DeleteFile("/test.dat");

            files = await _firebaseStorage.ListFiles("/");
            fileList = files.ToList();
            Assert.IsNull(fileList.FirstOrDefault(file => file.Filename == "test.dat"));
        }
    }
}