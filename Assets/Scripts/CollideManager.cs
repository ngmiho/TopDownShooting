using UnityEngine;

public class CollideManager : MonoBehaviour
{
    Player playerS;
    public int minDamage;
    public int maxDamage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerS = collision.GetComponent<Player>();
            InvokeRepeating("DamagePlayer", 0, 0.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CancelInvoke("DamagePlayer");
        }
    }

}
