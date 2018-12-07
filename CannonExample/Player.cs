using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(WeaponComponent))]
public class Player : MonoBehaviour
{
    WeaponComponent m_weaponComponent;

    private void Awake()
    {
        m_weaponComponent = GetComponent<WeaponComponent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                m_weaponComponent.FireWeapon(hit.point);
            }
        }
    }
}
