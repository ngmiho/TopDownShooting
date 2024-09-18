using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusCloseButton : MonoBehaviour
{
    public Button button;
    public StatusUIManager statusUIManager;
    //Route
    public GameObject Route0;


    private void Start()
    {
        button = GetComponent<Button>();
        if (statusUIManager == null)
            statusUIManager = GetComponentInParent<StatusUIManager>();

        if (button != null)
            button.onClick.AddListener(Select);
    }

    private void Select()
    {
        //status - set
        FindObjectOfType<Player>().SetStatuses();
        FindObjectOfType<WeaponShot0>().SetAgi();
        FindObjectOfType<WeaponShot1>(true).SetAgi();

        if (statusUIManager != null)
            statusUIManager.gameObject.SetActive(false);
        //sound
        //FindObjectOfType<SpawnMonsterLevel01>().GetComponent<AudioSource>().enabled = true;

        //++CountRoute
        TextMeshProUGUI textMeshProUGUI = FindObjectOfType<RouteCount>().GetComponent<TextMeshProUGUI>();
        int text = int.Parse(textMeshProUGUI.text);
        textMeshProUGUI.text = (text + 1).ToString();
        //active Route
        FindObjectOfType<Route1>(true).gameObject.SetActive(true);

    }
}
