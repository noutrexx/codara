using System;
using Codara.Application;
using Codara.Domain;
using UnityEngine;

namespace Codara.Presentation
{
    public sealed class LessonPlayerController : MonoBehaviour
    {
        private LessonPlayerService player;
        public LessonSession Session { get; private set; }
        public event Action<LessonSession> Changed;

        public void Initialize(LessonPlayerService service, string sessionId, string lessonId, int exerciseCount)
        {
            player = service ?? throw new ArgumentNullException(nameof(service));
            Session = player.StartOrResume(sessionId, lessonId, exerciseCount);
            Changed?.Invoke(Session);
        }

        public ExerciseEvaluation Submit(string attemptId, ExerciseDefinition exercise, ExerciseAnswer answer)
        {
            EnsureInitialized();
            var result = player.Submit(Session, attemptId, exercise, answer);
            Changed?.Invoke(Session);
            return result;
        }

        public void ShowExplanation()
        {
            EnsureInitialized();
            player.ShowExplanation(Session);
            Changed?.Invoke(Session);
        }

        public void Continue()
        {
            EnsureInitialized();
            player.Continue(Session);
            Changed?.Invoke(Session);
        }

        private void EnsureInitialized()
        {
            if (player == null || Session == null) throw new InvalidOperationException("LessonPlayerController is not initialized.");
        }
    }
}
