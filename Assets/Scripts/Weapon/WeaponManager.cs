using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] public int WeaponLevel = 0;
    [SerializeField] public int WeaponType = 0;

    public void UpgradeWeaponLevel()
    {
        if (this.WeaponLevel > -1 && this.WeaponLevel < 2)
            ++this.WeaponLevel;
    }

    public void ToggleWeapon(int weaponType)
    {
        WeaponType = weaponType;

        switch (weaponType)
        {
            case 0:
                GetComponentInChildren<WeaponShot0>(true).gameObject.SetActive(true);
                GetComponentInChildren<WeaponShot1>(true).gameObject.SetActive(false);
                break;
            case 1:
                GetComponentInChildren<WeaponShot0>(true).gameObject.SetActive(false);
                GetComponentInChildren<WeaponShot1>(true).gameObject.SetActive(true);
                break;
        }
    }

    void Update()
    {
        //Rotate
        GetComponentInChildren<Rotate>().RotateByVector3OfGameObject(Input.mousePosition);

        //Shoot
        switch (WeaponType)
        {
            case 0:
                if (Input.GetMouseButton(0)) //0 LMouse 1 RMouse 2SpinnerMouse
                {
                    if (WeaponLevel == 0)
                        GetComponentInChildren<WeaponShot0>().Shoot0(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    else if (WeaponLevel == 1)
                        GetComponentInChildren<WeaponShot0>().Shoot1(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    else if (WeaponLevel == 2)
                        GetComponentInChildren<WeaponShot0>().Shoot2(Input.mousePosition);
                }
                break;
            case 1:
                if (Input.GetMouseButton(0))
                {
                    if (WeaponLevel == 0)
                        GetComponentInChildren<WeaponShot1>().Shoot0(Input.mousePosition, 0);
                    else if (WeaponLevel == 1)
                        GetComponentInChildren<WeaponShot1>().Shoot0(Input.mousePosition, 5);
                    else if (WeaponLevel == 2)
                        GetComponentInChildren<WeaponShot1>().Shoot0(Input.mousePosition, 10);
                }
                break;
        }
    }

}
