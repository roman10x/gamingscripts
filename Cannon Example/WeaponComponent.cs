using UnityEngine;

public class WeaponComponent : MonoBehaviour
{
    ProjectileSystem m_projectileSystem;
    [SerializeField]
    float m_projectileSpeed;

    private void Start()
    {
        m_projectileSystem = ProjectileSystem.GetInstance();
    }

    public void FireWeapon(Vector3 _target)
    {
        m_projectileSystem.FireProjectile(transform.position, _target, m_projectileSpeed);
    }
}
