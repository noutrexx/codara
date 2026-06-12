using Codara.Presentation;
using UnityEditor;
using UnityEditor.Events;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Codara.Editor
{
    public static class CodaraDemoScaffolder
    {
        private const string ScenePath = "Assets/Codara/Scenes/CodaraDemo.unity";

        [MenuItem("Codara/Create Playable Demo")]
        public static void CreatePlayableDemo()
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            var camera = new GameObject("Camera", typeof(Camera)).GetComponent<Camera>();
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = new Color32(8, 9, 13, 255);

            var canvas = new GameObject("Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            var scaler = canvas.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1080, 1920);
            scaler.matchWidthOrHeight = 0.5f;
            new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));

            var panel = Panel(canvas.transform, "Dashboard", new Color32(20, 22, 29, 255), new Vector2(820, 1250));
            Text(panel.transform, "CODARA", 70, new Vector2(0, 500), new Color32(145, 72, 255, 255));
            Text(panel.transform, "Nox sistemleri hazır. Bugünkü rotana devam et.", 32, new Vector2(0, 410), Color.white);
            var bytes = Text(panel.transform, "BYTE", 38, new Vector2(0, 260), Color.white);
            var streak = Text(panel.transform, "KOD ZİNCİRİ", 38, new Vector2(0, 150), new Color32(49, 240, 204, 255));
            var energy = Text(panel.transform, "İŞLEM GÜCÜ", 38, new Vector2(0, 40), Color.white);
            var quest = Text(panel.transform, "GÜNLÜK GÖREV", 34, new Vector2(0, -160), new Color32(255, 185, 64, 255));

            var sliderObject = new GameObject("EnergyBar", typeof(RectTransform), typeof(Slider));
            sliderObject.transform.SetParent(panel.transform, false);
            sliderObject.GetComponent<RectTransform>().sizeDelta = new Vector2(580, 50);
            sliderObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -60);
            var slider = sliderObject.GetComponent<Slider>();
            slider.value = 0.8f;

            var buttonObject = Panel(panel.transform, "Complete Lesson", new Color32(145, 72, 255, 255), new Vector2(580, 110));
            buttonObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -420);
            var button = buttonObject.AddComponent<Button>();
            Text(buttonObject.transform, "DERSİ TAMAMLA", 32, Vector2.zero, Color.white);

            var controller = panel.AddComponent<GamificationDemoController>();
            Set(controller, "byteLabel", bytes);
            Set(controller, "streakLabel", streak);
            Set(controller, "energyLabel", energy);
            Set(controller, "questLabel", quest);
            Set(controller, "energySlider", slider);
            UnityEventTools.AddPersistentListener(button.onClick, controller.SimulateLesson);

            EditorSceneManager.SaveScene(scene, ScenePath);
            AssetDatabase.SaveAssets();
            Debug.Log("Codara playable demo is ready.");
        }

        private static GameObject Panel(Transform parent, string name, Color color, Vector2 size)
        {
            var obj = new GameObject(name, typeof(RectTransform), typeof(Image));
            obj.transform.SetParent(parent, false);
            obj.GetComponent<RectTransform>().sizeDelta = size;
            obj.GetComponent<Image>().color = color;
            return obj;
        }

        private static Text Text(Transform parent, string value, float size, Vector2 position, Color color)
        {
            var obj = new GameObject(value, typeof(RectTransform), typeof(Text));
            obj.transform.SetParent(parent, false);
            var rect = obj.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(720, 100);
            rect.anchoredPosition = position;
            var text = obj.GetComponent<Text>();
            text.text = value;
            text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            text.fontSize = Mathf.RoundToInt(size);
            text.alignment = TextAnchor.MiddleCenter;
            text.color = color;
            return text;
        }

        private static void Set(Object target, string property, Object value)
        {
            var serialized = new SerializedObject(target);
            serialized.FindProperty(property).objectReferenceValue = value;
            serialized.ApplyModifiedPropertiesWithoutUndo();
        }
    }
}
