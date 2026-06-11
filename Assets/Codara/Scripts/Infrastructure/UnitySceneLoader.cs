using System;
using System.Threading;
using System.Threading.Tasks;
using Codara.Application;
using UnityEngine.SceneManagement;

namespace Codara.Infrastructure
{
    public sealed class UnitySceneLoader : ISceneLoader
    {
        public bool CanLoad(string sceneName)
        {
            return !string.IsNullOrWhiteSpace(sceneName) &&
                   ApplicationCanStreamedLevelBeLoaded(sceneName);
        }

        public async Task LoadAsync(string sceneName, CancellationToken cancellationToken)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            if (operation == null)
            {
                throw new InvalidOperationException($"Could not start loading scene: {sceneName}");
            }

            while (!operation.isDone)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Yield();
            }
        }

        private static bool ApplicationCanStreamedLevelBeLoaded(string sceneName)
        {
            return UnityEngine.Application.CanStreamedLevelBeLoaded(sceneName);
        }
    }
}
