using System;
using System.Threading;
using System.Threading.Tasks;

namespace Codara.Application
{
    public sealed class SceneTransitionService : ISceneTransitionService
    {
        private readonly ISceneLoader sceneLoader;
        private readonly ILoadingScreen loadingScreen;
        private readonly IErrorHandler errorHandler;

        public SceneTransitionService(
            ISceneLoader sceneLoader,
            ILoadingScreen loadingScreen,
            IErrorHandler errorHandler)
        {
            this.sceneLoader = sceneLoader ?? throw new ArgumentNullException(nameof(sceneLoader));
            this.loadingScreen = loadingScreen ?? throw new ArgumentNullException(nameof(loadingScreen));
            this.errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
        }

        public bool IsTransitioning { get; private set; }

        public async Task LoadAsync(string sceneName, CancellationToken cancellationToken = default)
        {
            if (IsTransitioning)
            {
                throw new InvalidOperationException("A scene transition is already in progress.");
            }

            if (string.IsNullOrWhiteSpace(sceneName) || !sceneLoader.CanLoad(sceneName))
            {
                throw new ArgumentException($"Scene is not available in Build Settings: {sceneName}", nameof(sceneName));
            }

            IsTransitioning = true;
            loadingScreen.Show();

            try
            {
                await sceneLoader.LoadAsync(sceneName, cancellationToken);
            }
            catch (Exception exception)
            {
                errorHandler.Handle(exception);
                throw;
            }
            finally
            {
                loadingScreen.Hide();
                IsTransitioning = false;
            }
        }
    }
}

