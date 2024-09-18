using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPointerEnter : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip buttonSound;
    public AudioSource audioSource;

    private void Start()
    {
        //sound button - mouse hover
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioSource != null)
            audioSource.PlayOneShot(buttonSound);
    }
}
