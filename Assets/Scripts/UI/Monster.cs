using TMPro;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public TextMeshProUGUI valueText;

    //audio
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Start()
    {
        //audio
        if (audioSource == null)
            audioSource = FindObjectOfType<Audio>().GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    public void UpdateMonster(int maxValue)
    {
        int currentValue = int.Parse(valueText.text);
        int newValue = ++currentValue;
        if (newValue <= maxValue)
            valueText.text = newValue.ToString();
    }
}
