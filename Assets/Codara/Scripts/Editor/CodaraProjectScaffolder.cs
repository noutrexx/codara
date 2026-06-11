using System.IO;
using System.Linq;
using Codara.Application;
using Codara.Presentation;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Codara.Editor
{
    public static class CodaraProjectScaffolder
    {
        private const string Root = "Assets/Codara";
        private const string SceneRoot = Root + "/Scenes";

        private static readonly string[] RequiredDirectories =
        {
            Root + "/Art",
            Root + "/Audio",
            Root + "/Data/Courses",
            Root + "/Data/Lessons",
            Root + "/Data/Exercises",
            Root + "/Data/Achievements",
            Root + "/Data/Quests",
            Root + "/Prefabs",
            SceneRoot
        };

        [MenuItem("Codara/Setup Project")]
        public static void SetupProject()
        {
            foreach (var directory in RequiredDirectories)
            {
                Directory.CreateDirectory(directory);
            }

            foreach (var sceneName in SceneNames.All)
            {
                var scenePath = GetScenePath(sceneName);
                if (File.Exists(scenePath))
                {
                    continue;
                }

                var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
                if (sceneName == SceneNames.Bootstrap)
                {
                    new GameObject(nameof(ApplicationCompositionRoot)).AddComponent<ApplicationCompositionRoot>();
                }

                EditorSceneManager.SaveScene(scene, scenePath);
            }

            EditorBuildSettings.scenes = SceneNames.All
                .Select(name => new EditorBuildSettingsScene(GetScenePath(name), true))
                .ToArray();

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log("Codara project structure and scenes are ready.");
        }

        private static string GetScenePath(string sceneName)
        {
            return $"{SceneRoot}/{sceneName}.unity";
        }
    }
}
