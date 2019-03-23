using UnityEngine;
using UnityEngine.UI;

public class RawImageScrolling : MonoBehaviour
{
    [SerializeField] private Vector2 m_scrollSpeed = Vector2.zero;
    private RawImage m_rawImage;
    private Rect m_uvRect;

    private void Awake()
    {
        m_rawImage = GetComponent<RawImage>();
        m_uvRect = m_rawImage.uvRect;
    }

    private void Update()
    {
        m_uvRect.x -= m_scrollSpeed.x * Time.deltaTime;
        m_uvRect.y -= m_scrollSpeed.y * Time.deltaTime;
        m_rawImage.uvRect = m_uvRect;
    }
}
