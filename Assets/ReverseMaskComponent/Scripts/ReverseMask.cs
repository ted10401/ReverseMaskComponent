
namespace UnityEngine.UI
{
    [AddComponentMenu("UI/ReverseMask")]
    public class ReverseMask : Image
    {
        static protected Material s_DefaultReverseMaskMaterial = null;

        static public Material defaultReverseMaskMaterial
        {
            get
            {
                if (s_DefaultReverseMaskMaterial == null)
                {
                    s_DefaultReverseMaskMaterial = ReverseMaskUtility.GetReverseMaskMaterial();
                }

                return s_DefaultReverseMaskMaterial;
            }
        }

        /// <summary>
        /// The specified Material used by this Image. The default Material is used instead if one wasn't specified.
        /// </summary>
        public override Material material
        {
            get
            {
                return defaultReverseMaskMaterial;
            }

            set
            {
                base.material = value;
            }
        }
    }
}