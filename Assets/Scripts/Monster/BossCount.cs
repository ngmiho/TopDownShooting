using System.Collections;
using UnityEngine;

public class BossCount : MonoBehaviour
{
    private void OnDestroy()
    {
        StartCoroutineFromPersistentObject(SetUIStore());
    }


    public void StartCoroutineFromPersistentObject(IEnumerator coroutine)
    {
        var persistentObject = Camera.main?.gameObject;
        if (persistentObject != null)
        {
            persistentObject.GetComponent<MonoBehaviour>().StartCoroutine(coroutine);
        }
    }

    public IEnumerator SetUIStore()
    {
        yield return new WaitForSeconds(2f);

        Time.timeScale = 0f;
        FindObjectOfType<StoreUIManager>(true).gameObject.SetActive(true);

    }
}
