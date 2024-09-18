using UnityEngine;
using UnityEngine.UI;

public class SwitchManager : MonoBehaviour
{
    public Button[] buttons;
    private void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        if (buttons != null)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                int weaponType = i;
                buttons[i].onClick.AddListener(() => Switch(weaponType));
            }
        }
    }

    public void Switch(int weaponType)
    {
        FindObjectOfType<WeaponManager>().ToggleWeapon(weaponType);
    }
}
