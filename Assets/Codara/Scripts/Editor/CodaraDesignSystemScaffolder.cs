using System.IO;
using System.Collections.Generic;
using Codara.Presentation.DesignSystem;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Codara.Editor
{
    public static class CodaraDesignSystemScaffolder
    {
        private const string DesignRoot = "Assets/Codara/Data/DesignSystem";
        private const string ThemePath = DesignRoot + "/CodaraDarkTheme.asset";
        private const string NoxPath = "Assets/Codara/Prefabs/Nox.prefab";
        private const string PreviewPath = "Assets/Codara/Scenes/DesignSystemPreview.unity";

        [MenuItem("Codara/Setup Design System")]
        public static void SetupDesignSystem()
        {
            Directory.CreateDirectory(DesignRoot);
            Directory.CreateDirectory("Assets/Codara/Prefabs");

            var theme = AssetDatabase.LoadAssetAtPath<CodaraTheme>(ThemePath);
            if (theme == null)
            {
                theme = ScriptableObject.CreateInstance<CodaraTheme>();
                AssetDatabase.CreateAsset(theme, ThemePath);
            }

            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            var cameraObject = new GameObject("Camera", typeof(Camera));
            cameraObject.GetComponent<Camera>().backgroundColor = theme.GetColor(ColorToken.Background);
            cameraObject.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;

            var canvasObject = new GameObject("Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            var canvas = canvasObject.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            var scaler = canvasObject.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1080f, 1920f);
            scaler.matchWidthOrHeight = 0.5f;

            CreatePanel(canvasObject.transform, "Primary", new Vector2(-260f, 500f), theme.GetColor(ColorToken.Primary));
            CreatePanel(canvasObject.transform, "Secondary", new Vector2(260f, 500f), theme.GetColor(ColorToken.Secondary));
            CreatePanel(canvasObject.transform, "Success", new Vector2(-260f, 260f), theme.GetColor(ColorToken.Success));
            CreatePanel(canvasObject.transform, "Error", new Vector2(260f, 260f), theme.GetColor(ColorToken.Error));
            CreatePanel(canvasObject.transform, "Surface", new Vector2(0f, -40f), theme.GetColor(ColorToken.SurfaceRaised), new Vector2(720f, 280f));

            var nox = CreateNox(canvasObject.transform, theme);
            PrefabUtility.SaveAsPrefabAssetAndConnect(nox, NoxPath, InteractionMode.AutomatedAction);
            EditorSceneManager.SaveScene(scene, PreviewPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log("Codara design system assets are ready.");
        }

        private static void CreatePanel(Transform parent, string name, Vector2 position, Color color, Vector2? size = null)
        {
            var panel = new GameObject(name, typeof(RectTransform), typeof(Image));
            panel.transform.SetParent(parent, false);
            var rect = panel.GetComponent<RectTransform>();
            rect.sizeDelta = size ?? new Vector2(400f, 180f);
            rect.anchoredPosition = position;
            panel.GetComponent<Image>().color = color;
        }

        private static GameObject CreateNox(Transform parent, CodaraTheme theme)
        {
            var root = new GameObject("Nox", typeof(RectTransform));
            root.transform.SetParent(parent, false);
            root.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -500f);
            var segments = new List<Image>();

            for (var index = 0; index < 5; index++)
            {
                var segment = new GameObject($"Segment {index + 1}", typeof(RectTransform), typeof(Image));
                segment.transform.SetParent(root.transform, false);
                var rect = segment.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(130f - index * 12f, 130f - index * 12f);
                rect.anchoredPosition = new Vector2(index * 72f - 145f, Mathf.Sin(index * 1.2f) * 70f);
                rect.localRotation = Quaternion.Euler(0f, 0f, index * 14f);
                var image = segment.GetComponent<Image>();
                image.color = index == 0
                    ? theme.GetColor(ColorToken.Secondary)
                    : theme.GetColor(ColorToken.Primary);
                segments.Add(image);
            }

            var nox = root.AddComponent<GeometricNox>();
            var serializedNox = new SerializedObject(nox);
            var segmentProperty = serializedNox.FindProperty("segments");
            segmentProperty.arraySize = segments.Count;
            for (var index = 0; index < segments.Count; index++)
            {
                segmentProperty.GetArrayElementAtIndex(index).objectReferenceValue = segments[index];
            }
            serializedNox.ApplyModifiedPropertiesWithoutUndo();
            return root;
        }
    }
}
