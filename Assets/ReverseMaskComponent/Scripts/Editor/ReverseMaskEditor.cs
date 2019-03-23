using UnityEditor.AnimatedValues;
using UnityEngine.UI;


namespace UnityEditor.UI
{
    [CustomEditor(typeof(ReverseMask), true)]
    [CanEditMultipleObjects]
    /// <summary>
    ///   Custom Editor for the ReverseMask Component.
    /// </summary>
    public class ReverseMaskEditor : ImageEditor
    {
        SerializedProperty m_Sprite;
        SerializedProperty m_Type;
        SerializedProperty m_PreserveAspect;
        SerializedProperty m_UseSpriteMesh;
        AnimBool m_NewShowType;

        protected override void OnEnable()
        {
            base.OnEnable();

            m_Sprite = serializedObject.FindProperty("m_Sprite");
            m_Type = serializedObject.FindProperty("m_Type");
            m_PreserveAspect = serializedObject.FindProperty("m_PreserveAspect");
            m_UseSpriteMesh = serializedObject.FindProperty("m_UseSpriteMesh");

            m_NewShowType = new AnimBool(m_Sprite.objectReferenceValue != null);
            m_NewShowType.valueChanged.AddListener(Repaint);

            SetShowNativeSize(true);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            m_NewShowType.valueChanged.RemoveListener(Repaint);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SpriteGUI();
            EditorGUILayout.PropertyField(m_Color);
            RaycastControlsGUI();

            m_NewShowType.target = m_Sprite.objectReferenceValue != null;
            if (EditorGUILayout.BeginFadeGroup(m_NewShowType.faded))
                TypeGUI();
            EditorGUILayout.EndFadeGroup();

            SetShowNativeSize(false);
            if (EditorGUILayout.BeginFadeGroup(m_ShowNativeSize.faded))
            {
                EditorGUI.indentLevel++;

                if ((Image.Type)m_Type.enumValueIndex == Image.Type.Simple)
                    EditorGUILayout.PropertyField(m_UseSpriteMesh);

                EditorGUILayout.PropertyField(m_PreserveAspect);
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndFadeGroup();
            NativeSizeButtonGUI();

            serializedObject.ApplyModifiedProperties();
        }

        void SetShowNativeSize(bool instant)
        {
            Image.Type type = (Image.Type)m_Type.enumValueIndex;
            bool showNativeSize = (type == Image.Type.Simple || type == Image.Type.Filled) && m_Sprite.objectReferenceValue != null;
            base.SetShowNativeSize(showNativeSize, instant);
        }
    }
}


//using UnityEditor;
//using UnityEngine;
//using UnityEngine.UI;

//[CustomEditor(typeof(ReverseMask))]
//public class ReverseMaskEditor : Editor
//{
//    private SerializedProperty m_Sprite;
//    private SerializedProperty m_Color;
//    private SerializedProperty m_RaycastTarget;
//    private SerializedProperty m_Type;

//    private void OnEnable()
//    {
//        m_Sprite = serializedObject.FindProperty("m_Sprite");
//        m_Color = serializedObject.FindProperty("m_Color");
//        m_RaycastTarget = serializedObject.FindProperty("m_RaycastTarget");
//        m_Type = serializedObject.FindProperty("m_Type");
//    }

//    public override void OnInspectorGUI()
//    {
//        serializedObject.Update();
//        EditorGUILayout.PropertyField(m_Sprite);
//        EditorGUILayout.PropertyField(m_Color);
//        EditorGUILayout.PropertyField(m_RaycastTarget);
//        EditorGUILayout.PropertyField(m_Type);

//        if (GUILayout.Button("Set Native Size"))
//        {
//            ((Image)target).SetNativeSize();
//        }

//        serializedObject.ApplyModifiedProperties();
//    }
//}
