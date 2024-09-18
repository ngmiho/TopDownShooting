using UnityEngine;
using UnityEngine.UI;

public class BeginUIManager : MonoBehaviour
{
    public Button button;

    //audio
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Start()
    {
        button = GetComponentInChildren<Button>();
        if (button != null)
            button.onClick.AddListener(Select);

        //audio
        if (audioSource == null)
            audioSource = FindObjectOfType<Audio>().GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

    }

    private void Select()
    {
        gameObject.SetActive(false);
        FindObjectOfType<StatusUIManager>(true).gameObject.SetActive(true);
        FindObjectOfType<Monster>(true).gameObject.SetActive(true);
    }
}
