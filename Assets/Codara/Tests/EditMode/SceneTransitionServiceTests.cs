using System;
using System.Threading;
using System.Threading.Tasks;
using Codara.Application;
using NUnit.Framework;

namespace Codara.Tests.EditMode
{
    public sealed class SceneTransitionServiceTests
    {
        [Test]
        public void LoadAsync_ShowsAndHidesLoadingScreen()
        {
            var loader = new FakeSceneLoader();
            var loading = new FakeLoadingScreen();
            var service = new SceneTransitionService(loader, loading, new ErrorHandler());

            service.LoadAsync(SceneNames.Home).GetAwaiter().GetResult();

            Assert.That(loader.LoadedScene, Is.EqualTo(SceneNames.Home));
            Assert.That(loading.ShowCount, Is.EqualTo(1));
            Assert.That(loading.HideCount, Is.EqualTo(1));
            Assert.That(service.IsTransitioning, Is.False);
        }

        [Test]
        public void LoadAsync_RejectsUnknownScene()
        {
            var service = new SceneTransitionService(
                new FakeSceneLoader { CanLoadScene = false },
                new FakeLoadingScreen(),
                new ErrorHandler());

            try
            {
                service.LoadAsync("Missing").GetAwaiter().GetResult();
                Assert.Fail("Expected an ArgumentException.");
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void LoadAsync_RejectsConcurrentTransition()
        {
            var loader = new FakeSceneLoader { WaitForCompletion = true };
            var service = new SceneTransitionService(loader, new FakeLoadingScreen(), new ErrorHandler());
            var firstTransition = service.LoadAsync(SceneNames.Home);

            Assert.Throws<InvalidOperationException>(
                () => service.LoadAsync(SceneNames.Profile).GetAwaiter().GetResult());

            loader.Complete();
            firstTransition.GetAwaiter().GetResult();
        }

        private sealed class FakeSceneLoader : ISceneLoader
        {
            public bool CanLoadScene { get; set; } = true;
            public bool WaitForCompletion { get; set; }
            public string LoadedScene { get; private set; }
            private readonly TaskCompletionSource<bool> completion = new TaskCompletionSource<bool>();

            public bool CanLoad(string sceneName) => CanLoadScene;

            public Task LoadAsync(string sceneName, CancellationToken cancellationToken)
            {
                LoadedScene = sceneName;
                return WaitForCompletion ? completion.Task : Task.CompletedTask;
            }

            public void Complete() => completion.TrySetResult(true);
        }

        private sealed class FakeLoadingScreen : ILoadingScreen
        {
            public bool IsVisible { get; private set; }
            public int ShowCount { get; private set; }
            public int HideCount { get; private set; }

            public void Show()
            {
                IsVisible = true;
                ShowCount++;
            }

            public void Hide()
            {
                IsVisible = false;
                HideCount++;
            }
        }
    }
}
