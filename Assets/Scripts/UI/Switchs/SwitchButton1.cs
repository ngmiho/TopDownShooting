using UnityEngine;

public class SwitchButton1 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
            FindObjectOfType<WeaponManager>().ToggleWeapon(1);
    }
}
