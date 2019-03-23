
namespace UnityEngine.UI
{
    [AddComponentMenu("UI/Reverse Mask Layer")]
    public class ReverseMaskLayer : Image
    {
        static protected Material s_DefaultReverseMaskBackgroundMaterial = null;

        static public Material defaultReverseMaskLayerMaterial
        {
            get
            {
                if (s_DefaultReverseMaskBackgroundMaterial == null)
                {
                    s_DefaultReverseMaskBackgroundMaterial = ReverseMaskUtility.GetReverseMaskLayerMaterial();
                }

                return s_DefaultReverseMaskBackgroundMaterial;
            }
        }

        /// <summary>
        /// The specified Material used by this Image. The default Material is used instead if one wasn't specified.
        /// </summary>
        public override Material material
        {
            get
            {
                return defaultReverseMaskLayerMaterial;
            }

            set
            {
                base.material = value;
            }
        }
    }
}