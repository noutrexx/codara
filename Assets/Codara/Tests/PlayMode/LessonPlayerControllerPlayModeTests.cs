using System.Collections;
using System.Collections.Generic;
using Codara.Application;
using Codara.Domain;
using Codara.Infrastructure;
using Codara.Presentation;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Codara.Tests.PlayMode
{
    public sealed class LessonPlayerControllerPlayModeTests
    {
        [UnityTest]
        public IEnumerator Controller_RunsCompleteLessonFlow()
        {
            var gameObject = new GameObject("LessonPlayer", typeof(LessonPlayerController));
            var controller = gameObject.GetComponent<LessonPlayerController>();
            controller.Initialize(new LessonPlayerService(new ExerciseEvaluationEngine(),
                new LocalLessonSessionRepository(new MemorySaveService())), "session", "lesson", 1);
            var exercise = new ExerciseDefinition("e1", ExerciseType.ShortAnswer, "", "", ExerciseAnswer.From("ok"));

            controller.Submit("a1", exercise, ExerciseAnswer.From("OK"));
            controller.ShowExplanation();
            controller.Continue();
            yield return null;

            Assert.That(controller.Session.State, Is.EqualTo(LessonSessionState.Completed));
            Object.Destroy(gameObject);
        }

        private sealed class MemorySaveService : ILocalSaveService
        {
            private readonly Dictionary<string, string> data = new();
            public bool Exists(string key) => data.ContainsKey(key);
            public string Load(string key) => data.TryGetValue(key, out var value) ? value : null;
            public void Save(string key, string content) => data[key] = content;
            public void Delete(string key) => data.Remove(key);
        }
    }
}
