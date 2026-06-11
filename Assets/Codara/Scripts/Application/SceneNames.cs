using System;
using System.Collections.Generic;

namespace Codara.Application
{
    public static class SceneNames
    {
        public const string Bootstrap = "Bootstrap";
        public const string Welcome = "Welcome";
        public const string Authentication = "Authentication";
        public const string Onboarding = "Onboarding";
        public const string Home = "Home";
        public const string LearningPath = "LearningPath";
        public const string Lesson = "Lesson";
        public const string LessonResult = "LessonResult";
        public const string Practice = "Practice";
        public const string Profile = "Profile";
        public const string Arena = "Arena";
        public const string Shop = "Shop";
        public const string Settings = "Settings";

        public static IReadOnlyList<string> All { get; } = Array.AsReadOnly(new[]
        {
            Bootstrap,
            Welcome,
            Authentication,
            Onboarding,
            Home,
            LearningPath,
            Lesson,
            LessonResult,
            Practice,
            Profile,
            Arena,
            Shop,
            Settings
        });
    }
}
