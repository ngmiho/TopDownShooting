using UnityEngine;

public class Route1 : MonoBehaviour
{
    private void Start()
    {
        ExecuteSpawn();
        Invoke("DisableSelf", 1.5f);
    }

    public void ExecuteSpawn()
    {
        //active route
        FindObjectOfType<UIManager>().GetComponentInChildren<SpawnMonsterLevel01>(true).enabled = true;
    }

    public void DisableSelf()
    {
        gameObject.SetActive(false);
    }
}
