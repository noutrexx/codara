using System;
using System.Collections.Generic;
using Codara.Application;
using Codara.Domain;
using UnityEngine;

namespace Codara.Presentation
{
    public sealed class SkillAnalysisController : MonoBehaviour
    {
        private MistakeLearningService learningService;
        private IMistakeRepository repository;

        public IReadOnlyList<SkillAnalysis> Analysis { get; private set; } = Array.Empty<SkillAnalysis>();
        public event Action<IReadOnlyList<SkillAnalysis>> Changed;

        public void Initialize(MistakeLearningService service, IMistakeRepository mistakeRepository)
        {
            learningService = service ?? throw new ArgumentNullException(nameof(service));
            repository = mistakeRepository ?? throw new ArgumentNullException(nameof(mistakeRepository));
            Refresh();
        }

        public void Refresh()
        {
            if (learningService == null || repository == null) throw new InvalidOperationException("SkillAnalysisController is not initialized.");
            Analysis = learningService.Analyze(repository.Load());
            Changed?.Invoke(Analysis);
        }
    }
}
