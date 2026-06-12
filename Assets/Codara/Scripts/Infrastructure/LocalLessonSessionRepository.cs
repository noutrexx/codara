using System;
using System.Collections.Generic;
using Codara.Application;
using Codara.Domain;
using UnityEngine;

namespace Codara.Infrastructure
{
    public sealed class LocalLessonSessionRepository : ILessonSessionRepository
    {
        private readonly ILocalSaveService saves;
        public LocalLessonSessionRepository(ILocalSaveService saves) => this.saves = saves ?? throw new ArgumentNullException(nameof(saves));

        public LessonSession Load(string lessonId)
        {
            var json = saves.Load(Key(lessonId));
            if (string.IsNullOrWhiteSpace(json)) return null;
            try
            {
                var data = JsonUtility.FromJson<SessionData>(json);
                if (data == null || data.version != 1) return null;
                return LessonSession.Restore(new LessonSessionSnapshot(data.sessionId, data.lessonId, data.exerciseCount,
                    data.currentIndex, data.earnedBytes, data.computePowerLost, (LessonSessionState)data.state, data.completedExerciseIds));
            }
            catch (ArgumentException) { return null; }
        }

        public void Save(LessonSession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            var snapshot = session.CreateSnapshot();
            saves.Save(Key(session.LessonId), JsonUtility.ToJson(new SessionData
            {
                version = 1,
                sessionId = snapshot.SessionId,
                lessonId = snapshot.LessonId,
                exerciseCount = snapshot.ExerciseCount,
                currentIndex = snapshot.CurrentIndex,
                earnedBytes = snapshot.EarnedBytes,
                computePowerLost = snapshot.ComputePowerLost,
                state = (int)snapshot.State,
                completedExerciseIds = new List<string>(snapshot.CompletedExerciseIds)
            }));
        }

        public void Delete(string lessonId) => saves.Delete(Key(lessonId));
        private static string Key(string lessonId) => "lesson-session-" + lessonId;

        [Serializable]
        private sealed class SessionData
        {
            public int version;
            public string sessionId;
            public string lessonId;
            public int exerciseCount;
            public int currentIndex;
            public int earnedBytes;
            public int computePowerLost;
            public int state;
            public List<string> completedExerciseIds = new();
        }
    }
}
