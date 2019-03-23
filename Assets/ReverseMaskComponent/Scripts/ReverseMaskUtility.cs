
namespace UnityEngine.UI
{
    public static class ReverseMaskUtility
    {
        private const string REVERSE_MASK_SHADER_NAME = "UI/ReverseMask";
        private const string REVERSE_MASK_BACKGROUND_SHADER_NAME = "UI/ReverseMaskBackground";

        public static Material GetReverseMaskMaterial()
        {
            return new Material(Shader.Find(REVERSE_MASK_SHADER_NAME));
        }

        public static Material GetReverseMaskBackgroundMaterial()
        {
            return new Material(Shader.Find(REVERSE_MASK_BACKGROUND_SHADER_NAME));
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("GameObject/UI/Reverse Mask")]
        private static void ReverseMask()
        {

        }
#endif
    }
}