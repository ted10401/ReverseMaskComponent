using UnityEditor;

namespace UnityEngine.UI
{
    public class ReverseMaskComponentMenuItems
    {
        [MenuItem("GameObject/UI/Reverse Mask Layer", false, 2200)]
        private static void AddReverseMaskLayer()
        {
            CreateCanvasParent();

            if (Selection.activeGameObject)
            {
                if (Selection.activeGameObject.GetComponentInParent<Canvas>())
                {
                    CreateUI<ReverseMaskLayer>();
                }
            }
        }

        [MenuItem("GameObject/UI/Reverse Mask", false, 2201)]
        private static void AddReverseMask()
        {
            CreateCanvasParent();

            if (Selection.activeGameObject)
            {
                if (Selection.activeGameObject.GetComponentInParent<Canvas>())
                {
                    CreateUI<ReverseMask>();
                }
            }
        }

        private static void CreateCanvasParent()
        {
            if (!Selection.activeGameObject)
            {
                GameObject canvas = new GameObject("Canvas", typeof(Canvas));
                canvas.layer = LayerMask.NameToLayer("UI");
                canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.AddComponent<CanvasScaler>();
                canvas.AddComponent<GraphicRaycaster>();

                Selection.activeGameObject = canvas;
            }
        }

        private static void CreateUI<T>() where T : MaskableGraphic
        {
            GameObject instance = new GameObject(typeof(T).Name, typeof(T));
            instance.layer = LayerMask.NameToLayer("UI");
            instance.transform.SetParent(Selection.activeTransform, false);
            instance.GetComponent<T>().raycastTarget = false;

            Selection.activeGameObject = instance;
        }
    }

}