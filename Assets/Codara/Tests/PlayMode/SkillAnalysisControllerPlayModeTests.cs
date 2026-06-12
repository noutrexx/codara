using System;
using System.Collections;
using System.Collections.Generic;
using Codara.Application;
using Codara.Domain;
using Codara.Presentation;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Codara.Tests.PlayMode
{
    public sealed class SkillAnalysisControllerPlayModeTests
    {
        [UnityTest]
        public IEnumerator Controller_ExposesWeakSkills()
        {
            var repository = new MemoryMistakeRepository();
            repository.Save(new[] { new MistakeRecord("m1", "u1", "e1", "loops", MistakeCategory.LoopLogic,
                ExerciseAnswer.From("wrong"), ExerciseAnswer.From("right"), DateTimeOffset.UtcNow, 1) });
            var gameObject = new GameObject("SkillAnalysis", typeof(SkillAnalysisController));
            var controller = gameObject.GetComponent<SkillAnalysisController>();
            controller.Initialize(new MistakeLearningService(), repository);
            yield return null;
            Assert.That(controller.Analysis[0].SkillTag, Is.EqualTo("loops"));
            UnityEngine.Object.Destroy(gameObject);
        }

        private sealed class MemoryMistakeRepository : IMistakeRepository
        {
            private IReadOnlyList<MistakeRecord> records = Array.Empty<MistakeRecord>();
            public IReadOnlyList<MistakeRecord> Load() => records;
            public void Save(IReadOnlyList<MistakeRecord> mistakes) => records = mistakes;
        }
    }
}
