using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    bool m_isActive = false;
    Vector3 m_direction = Vector3.zero;
    float m_speed = 0;


    ProjectileSystem m_projectileSystem;

    private void Start()
    {
        m_projectileSystem = ProjectileSystem.GetInstance();
        m_projectileSystem.RegisterProjectile(this);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (m_isActive)
        {
            transform.Translate(m_direction * m_speed * Time.deltaTime);
        }
    }

    internal void FireProjectile(Vector3 _direction, float _speed)
    {
        m_isActive = true;
        m_direction = _direction;
        m_speed = _speed;
        StartCoroutine(DisableObjectDelayed(5));
    }

    private IEnumerator DisableObjectDelayed(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        m_isActive = false;
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(DisableObjectDelayed(0.1f));
    }
    private void OnDestroy()
    {
        if (m_projectileSystem != null) { m_projectileSystem.UnregisterProjectile(this); }
    }
}
