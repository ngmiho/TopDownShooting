using UnityEngine;

public class CoinDrop : MonoBehaviour
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
        animator.SetFloat("changing", changing);
    }

    public void Drop(Vector3 target)
    {
        Instantiate(gameObject, target, Quaternion.identity);

        //Sound
        audioSource.PlayOneShot(shootSound);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().coin.UpdateCoin(999);
            Destroy(gameObject);
        }
    }
}
