using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour , IAnchorUser
{
    Rigidbody2D m_rigidbody;
    AnchorSystem m_anchorSystem;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_anchorSystem = AnchorSystem.GetInstance();
    }

    Rigidbody2D IAnchorUser.GetRigidbody2D()
    {
        return m_rigidbody;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_anchorSystem.AttachToNearestAnchor(this);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_anchorSystem.Detach(this);
        }
    }
}
