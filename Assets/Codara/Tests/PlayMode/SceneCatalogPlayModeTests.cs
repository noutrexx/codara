using System.Collections;
using Codara.Application;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Codara.Tests.PlayMode
{
    public sealed class SceneCatalogPlayModeTests
    {
        [UnityTest]
        public IEnumerator EveryConfiguredScene_CanLoad()
        {
            foreach (var sceneName in SceneNames.All)
            {
                var operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
                Assert.That(operation, Is.Not.Null, $"Could not start loading {sceneName}.");

                while (!operation.isDone)
                {
                    yield return null;
                }

                Assert.That(SceneManager.GetActiveScene().name, Is.EqualTo(sceneName));
            }
        }
    }
}
