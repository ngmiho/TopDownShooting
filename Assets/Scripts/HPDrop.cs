using UnityEngine;
using UnityEngine.UI;

public class HPDrop : MonoBehaviour
{
    //Sound
    public AudioClip shootSound;
    public AudioSource audioSource;
    //animator
    public Animator animator;
    public float changing;

    void Start()
    {
        //animator
        changing = 0;

        //Sound
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        changing += Time.deltaTime;
        if (animator != null)
            animator.SetFloat("changing", changing);
    }

    public void Drop(Vector3 target)
    {
        Instantiate(gameObject, target, Quaternion.identity);

        //Sound
        audioSource.PlayOneShot(shootSound);

    }

    public Button Button;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Button[] buttons = FindObjectOfType<UIManager>().GetComponentInChildren<Slot>(true).buttons;
            int buttonLengh = buttons.Length;
            for (int i = 0; i < buttonLengh; i++)
            {
                if (!buttons[i].gameObject.activeSelf)
                {
                    buttons[i].gameObject.SetActive(true);
                    Destroy(gameObject);
                    return;
                }

            }
            //FindObjectOfType<Slot>().buttons[0].gameObject.SetActive(true);
            //Button.gameObject.SetActive(true);
        }
    }
}
