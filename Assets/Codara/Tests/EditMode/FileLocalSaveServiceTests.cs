using System;
using System.IO;
using Codara.Infrastructure;
using NUnit.Framework;

namespace Codara.Tests.EditMode
{
    public sealed class FileLocalSaveServiceTests
    {
        private string directory;

        [SetUp]
        public void SetUp()
        {
            directory = Path.Combine(Path.GetTempPath(), "CodaraTests", Guid.NewGuid().ToString("N"));
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
            }
        }

        [Test]
        public void Save_LoadAndDelete_RoundTripsContent()
        {
            var service = new FileLocalSaveService(directory);

            service.Save("progress", "{\"version\":1}");

            Assert.That(service.Exists("progress"), Is.True);
            Assert.That(service.Load("progress"), Is.EqualTo("{\"version\":1}"));

            service.Delete("progress");
            Assert.That(service.Exists("progress"), Is.False);
        }

        [Test]
        public void Load_RecoversInterruptedFirstWrite()
        {
            Directory.CreateDirectory(directory);
            File.WriteAllText(Path.Combine(directory, "progress.json.tmp"), "{\"version\":1}");
            var service = new FileLocalSaveService(directory);

            Assert.That(service.Load("progress"), Is.EqualTo("{\"version\":1}"));
            Assert.That(File.Exists(Path.Combine(directory, "progress.json")), Is.True);
        }
    }
}
