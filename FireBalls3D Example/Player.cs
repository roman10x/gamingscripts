using UnityEngine;

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
        //Hack for tutorial; Call FireWeapon from your own scripts!
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
