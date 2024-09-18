using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class StatusManager : MonoBehaviour
{
    public StatusText[] texts;
    public Button randomButton;

    void Start()
    {
        randomButton = GetComponentInChildren<StatusRandomButton>().gameObject.GetComponent<Button>();
        texts = GetComponentsInChildren<StatusText>();

        if (randomButton != null)
        {
            randomButton.onClick.AddListener(Select);
        }
        Select();
    }


    public void Select()
    {
        int hp = Random.Range(5, 10);
        int str = Random.Range(3, 10);
        int agi = Random.Range(3, 10);
        int spd = Random.Range(3, 10);
        if (hp > 7)
        {
            spd = Random.Range(3, 5);
        }
        if (str > 7)
        {
            agi = Random.Range(3, 5);
        }
        texts[0].gameObject.GetComponent<TextMeshProUGUI>().text = hp.ToString();
        texts[1].gameObject.GetComponent<TextMeshProUGUI>().text = str.ToString();
        texts[2].gameObject.GetComponent<TextMeshProUGUI>().text = agi.ToString();
        texts[3].gameObject.GetComponent<TextMeshProUGUI>().text = spd.ToString();

        //HealthBar - text
        FindObjectOfType<HealthText>().GetComponent<TextMeshProUGUI>().text = hp.ToString() + " / " + hp.ToString();
    }
}
