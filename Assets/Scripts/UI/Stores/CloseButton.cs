using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    private Button selectButton;

    void Start()
    {
        selectButton = GetComponent<Button>();
        if (selectButton != null)
        {
            selectButton.onClick.AddListener(Select);
        }
    }

    void Select()
    {
        Time.timeScale = 1;

        //active UIRoute2
        transform.parent.gameObject.SetActive(false);
        FindObjectOfType<Route2>(true).gameObject.SetActive(true);

        //sound - play
        FindObjectOfType<SpawnMonsterLevel01>().GetComponent<AudioSource>().enabled = true;
        FindObjectOfType<StoreUIManager>().gameObject.SetActive(false);
    }
}
