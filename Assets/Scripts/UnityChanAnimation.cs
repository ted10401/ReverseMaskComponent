using UnityEngine;

public class UnityChanAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 m_from;
    [SerializeField] private Vector3 m_to;
    [SerializeField] private float m_duration;

    private RectTransform m_rectTransform;
    private float m_lerp;

    private void Awake()
    {
        m_rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_lerp = 0;
        }

        m_lerp += Time.deltaTime;
        m_rectTransform.localPosition = Vector3.Lerp(m_from, m_to, m_lerp / m_duration);
    }
}
