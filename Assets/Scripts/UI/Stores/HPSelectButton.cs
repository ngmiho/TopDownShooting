using UnityEngine;
using UnityEngine.UI;

public class HPSelectButton : MonoBehaviour
{
    public Button SelectButton;
    //UI
    private Health health;
    private Coin coinUI;
    public Canvas AnnoucementUI;

    void Start()
    {
        health = FindObjectOfType<Player>().GetComponent<Health>();
        if (SelectButton != null)
        {
            SelectButton.onClick.AddListener(Select);
        }
    }

    void Select()
    {
        coinUI = FindObjectOfType<Coin>();
        int coins = int.Parse(coinUI.valueText.text.ToString());
        if (coins >= 5)
        {
            coins -= 5;
            coinUI.valueText.text = coins.ToString();
            health.RecoverHP(20);

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
