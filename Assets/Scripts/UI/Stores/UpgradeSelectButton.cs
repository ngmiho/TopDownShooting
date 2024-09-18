using UnityEngine;
using UnityEngine.UI;

public class UpgradeSelectButton : MonoBehaviour
{
    public Button selectButton;
    private WeaponManager weaponManager;
    //UI
    private Coin coinUI;
    public Canvas AnnoucementUI;

    void Start()
    {
        weaponManager = FindObjectOfType<WeaponManager>();
        if (selectButton != null)
        {
            selectButton.onClick.AddListener(Select);
        }
    }

    void Select()
    {
        coinUI = FindObjectOfType<Coin>();
        int coins = int.Parse(coinUI.valueText.text.ToString());
        if (coins >= 10)
        {
            coins -= 10;
            coinUI.valueText.text = coins.ToString();
            weaponManager.UpgradeWeaponLevel();

            Time.timeScale = 1;
            FindObjectOfType<StoreUIManager>().gameObject.SetActive(false);

            //active UIRoute2
            FindObjectOfType<Route2>(true).gameObject.SetActive(true);

            //sound - play
            FindObjectOfType<SpawnMonsterLevel01>().GetComponent<AudioSource>().enabled = true;

        }
        else
        {
            FindObjectOfType<AnnoucementNotEnough>(true).gameObject.SetActive(true);
        }
    }
}
