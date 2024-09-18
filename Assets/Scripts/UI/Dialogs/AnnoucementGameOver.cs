using System.Collections;
using UnityEngine;

public class AnnoucementGameOver : MonoBehaviour
{
    public string textTextMeshProUGUI;
    public string textButton;


    private void OnDestroy()
    {
        StartCoroutineFromPersistentObject(SetUIAnnoucement());
    }


    public void StartCoroutineFromPersistentObject(IEnumerator coroutine)
    {
        var persistentObject = Camera.main?.gameObject;
        if (persistentObject != null)
        {
            persistentObject.GetComponent<MonoBehaviour>().StartCoroutine(coroutine);
        }
    }

    public IEnumerator SetUIAnnoucement()
    {
        yield return new WaitForSeconds(2f);

        GameObject uiAnnoucement = FindObjectOfType<GameOver>(true).gameObject;
        uiAnnoucement.SetActive(true);
    }
}
