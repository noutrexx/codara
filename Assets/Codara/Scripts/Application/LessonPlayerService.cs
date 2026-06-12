using System;
using Codara.Domain;

namespace Codara.Application
{
    public interface ILessonSessionRepository
    {
        LessonSession Load(string lessonId);
        void Save(LessonSession session);
        void Delete(string lessonId);
    }

    public sealed class LessonPlayerService
    {
        private readonly ExerciseEvaluationEngine engine;
        private readonly ILessonSessionRepository repository;

        public LessonPlayerService(ExerciseEvaluationEngine engine, ILessonSessionRepository repository)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public LessonSession StartOrResume(string sessionId, string lessonId, int exerciseCount)
        {
            var session = repository.Load(lessonId) ?? new LessonSession(sessionId, lessonId, exerciseCount);
            if (session.State == LessonSessionState.Starting) session.Begin();
            repository.Save(session);
            return session;
        }

        public ExerciseEvaluation Submit(LessonSession session, string attemptId, ExerciseDefinition exercise, ExerciseAnswer answer)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            session.StartEvaluation();
            try
            {
                var result = engine.Evaluate(attemptId, exercise, answer);
                session.RecordEvaluation(result);
                repository.Save(session);
                return result;
            }
            catch
            {
                session.CancelEvaluation();
                repository.Save(session);
                throw;
            }
        }

        public void ShowExplanation(LessonSession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            session.ShowExplanation();
            repository.Save(session);
        }

        public void Continue(LessonSession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            session.Continue();
            if (session.State == LessonSessionState.Completed) repository.Delete(session.LessonId);
            else repository.Save(session);
        }
    }
}
