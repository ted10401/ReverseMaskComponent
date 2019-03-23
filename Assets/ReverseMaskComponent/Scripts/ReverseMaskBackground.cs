
namespace UnityEngine.UI
{
    [AddComponentMenu("UI/ReverseMaskBackground")]
    public class ReverseMaskBackground : Image
    {
        static protected Material s_DefaultReverseMaskBackgroundMaterial = null;

        static public Material defaultReverseMaskBackgroundMaterial
        {
            get
            {
                if (s_DefaultReverseMaskBackgroundMaterial == null)
                {
                    s_DefaultReverseMaskBackgroundMaterial = ReverseMaskUtility.GetReverseMaskBackgroundMaterial();
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
                return defaultReverseMaskBackgroundMaterial;
            }

            set
            {
                base.material = value;
            }
        }
    }
}