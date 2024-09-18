using UnityEngine;

public class Victory : MonoBehaviour
{
    //audio
    public AudioSource audioSource;
    public AudioClip audioClip;


    private void Start()
    {
        Time.timeScale = 0.0f;

        //audio
        if (audioSource == null)
            audioSource = FindObjectOfType<Audio>().GetComponent<AudioSource>();
        if (audioSource != null)
            audioSource.PlayOneShot(audioClip);
    }
}
