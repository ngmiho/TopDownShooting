using UnityEngine;
using UnityEngine.UI;

public class PotionButton : MonoBehaviour
{
    public Button SelectButton;
    //UI
    private Health health;

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
        health.RecoverHP(10);
        gameObject.SetActive(false);
        //gameObject.Get
    }

}
