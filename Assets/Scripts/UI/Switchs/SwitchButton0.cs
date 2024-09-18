using UnityEngine;

public class SwitchButton0 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            FindObjectOfType<WeaponManager>().ToggleWeapon(0);
    }
}
