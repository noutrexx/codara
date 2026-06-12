using System.Collections;
using Codara.Presentation;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Codara.Tests.PlayMode
{
    public sealed class GamificationDemoPlayModeTests
    {
        [UnityTest]
        public IEnumerator DemoController_CanSimulateLessonWithoutReferences()
        {
            var gameObject = new GameObject("Demo", typeof(GamificationDemoController));
            yield return null;
            Assert.DoesNotThrow(() => gameObject.GetComponent<GamificationDemoController>().SimulateLesson());
            Object.Destroy(gameObject);
        }
    }
}
