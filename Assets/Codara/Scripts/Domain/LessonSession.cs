using System;
using System.Collections.Generic;

namespace Codara.Domain
{
    public enum LessonSessionState
    {
        Starting,
        AwaitingAnswer,
        Evaluating,
        Feedback,
        Explanation,
        Completed
    }

    [Serializable]
    public sealed class LessonSession
    {
        private readonly HashSet<string> completedExerciseIds = new(StringComparer.Ordinal);

        public LessonSession(string sessionId, string lessonId, int exerciseCount)
        {
            if (string.IsNullOrWhiteSpace(sessionId)) throw new ArgumentException("Session id is required.", nameof(sessionId));
            if (string.IsNullOrWhiteSpace(lessonId)) throw new ArgumentException("Lesson id is required.", nameof(lessonId));
            if (exerciseCount <= 0) throw new ArgumentOutOfRangeException(nameof(exerciseCount));
            SessionId = sessionId;
            LessonId = lessonId;
            ExerciseCount = exerciseCount;
            State = LessonSessionState.Starting;
        }

        public string SessionId { get; }
        public string LessonId { get; }
        public int ExerciseCount { get; }
        public int CurrentIndex { get; private set; }
        public int EarnedBytes { get; private set; }
        public int ComputePowerLost { get; private set; }
        public LessonSessionState State { get; private set; }
        public bool InputLocked => State != LessonSessionState.AwaitingAnswer;
        public IReadOnlyCollection<string> CompletedExerciseIds => completedExerciseIds;

        public void Begin() => MoveFrom(LessonSessionState.Starting, LessonSessionState.AwaitingAnswer);
        public void StartEvaluation() => MoveFrom(LessonSessionState.AwaitingAnswer, LessonSessionState.Evaluating);
        public void CancelEvaluation() => MoveFrom(LessonSessionState.Evaluating, LessonSessionState.AwaitingAnswer);

        public void RecordEvaluation(ExerciseEvaluation evaluation)
        {
            if (State != LessonSessionState.Evaluating) throw new InvalidOperationException("Session is not evaluating.");
            if (!completedExerciseIds.Add(evaluation.ExerciseId)) throw new InvalidOperationException("Exercise was already completed.");
            EarnedBytes += evaluation.EarnedBytes;
            ComputePowerLost += evaluation.ComputePowerPenalty;
            State = LessonSessionState.Feedback;
        }

        public void ShowExplanation() => MoveFrom(LessonSessionState.Feedback, LessonSessionState.Explanation);

        public void Continue()
        {
            if (State != LessonSessionState.Explanation) throw new InvalidOperationException("Explanation must be shown first.");
            CurrentIndex++;
            State = CurrentIndex >= ExerciseCount ? LessonSessionState.Completed : LessonSessionState.AwaitingAnswer;
        }

        public LessonSessionSnapshot CreateSnapshot()
            => new LessonSessionSnapshot(SessionId, LessonId, ExerciseCount, CurrentIndex, EarnedBytes, ComputePowerLost, State, completedExerciseIds);

        public static LessonSession Restore(LessonSessionSnapshot snapshot)
        {
            if (snapshot == null) throw new ArgumentNullException(nameof(snapshot));
            var session = new LessonSession(snapshot.SessionId, snapshot.LessonId, snapshot.ExerciseCount)
            {
                CurrentIndex = snapshot.CurrentIndex,
                EarnedBytes = snapshot.EarnedBytes,
                ComputePowerLost = snapshot.ComputePowerLost,
                State = snapshot.State == LessonSessionState.Evaluating ? LessonSessionState.AwaitingAnswer : snapshot.State
            };
            foreach (var id in snapshot.CompletedExerciseIds) session.completedExerciseIds.Add(id);
            return session;
        }

        private void MoveFrom(LessonSessionState expected, LessonSessionState next)
        {
            if (State != expected) throw new InvalidOperationException($"Expected state {expected}, current state is {State}.");
            State = next;
        }
    }

    public sealed class LessonSessionSnapshot
    {
        public LessonSessionSnapshot(string sessionId, string lessonId, int exerciseCount, int currentIndex, int earnedBytes,
            int computePowerLost, LessonSessionState state, IEnumerable<string> completedExerciseIds)
        {
            SessionId = sessionId;
            LessonId = lessonId;
            ExerciseCount = exerciseCount;
            CurrentIndex = currentIndex;
            EarnedBytes = earnedBytes;
            ComputePowerLost = computePowerLost;
            State = state;
            CompletedExerciseIds = new List<string>(completedExerciseIds ?? Array.Empty<string>()).AsReadOnly();
        }
        public string SessionId { get; }
        public string LessonId { get; }
        public int ExerciseCount { get; }
        public int CurrentIndex { get; }
        public int EarnedBytes { get; }
        public int ComputePowerLost { get; }
        public LessonSessionState State { get; }
        public IReadOnlyList<string> CompletedExerciseIds { get; }
    }
}
