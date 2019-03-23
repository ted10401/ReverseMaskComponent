
namespace UnityEngine.UI
{
    public static class ReverseMaskUtility
    {
        private const string REVERSE_MASK_SHADER_NAME = "UI/ReverseMask";
        private const string REVERSE_MASK_LAYER_SHADER_NAME = "UI/ReverseMaskLayer";

        public static Material GetReverseMaskMaterial()
        {
            return new Material(Shader.Find(REVERSE_MASK_SHADER_NAME));
        }

        public static Material GetReverseMaskLayerMaterial()
        {
            return new Material(Shader.Find(REVERSE_MASK_LAYER_SHADER_NAME));
        }
    }
}