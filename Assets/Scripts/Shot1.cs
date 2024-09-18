using UnityEngine;

public class Shot1 : MonoBehaviour
{
    public GameObject bullet;
    public float bulletForce;
    public float TimeBtwFire = 1f;
    private float cooldown;

    private void Update()
    {
        cooldown -= Time.deltaTime;

        //Shoot
        Vector3 top = transform.position;
        Vector3 down = transform.position;
        Vector3 left = transform.position;
        Vector3 right = transform.position;
        top.y += 10;
        down.y -= 10;
        left.x += 10;
        right.x -= 10;

        Vector3 directionTop = top - transform.position;
        Vector3 directionDown = down - transform.position;
        Vector3 directionLeft = left - transform.position;
        Vector3 directionRight = right - transform.position;
        Shoot(directionTop, directionDown, directionLeft, directionRight);
    }


    public void Shoot(Vector3 top, Vector3 down, Vector3 left, Vector3 right)
    {
        if (cooldown > 0) return;
        cooldown = TimeBtwFire;

        GameObject bulletTmp0 = Instantiate(bullet, transform.position, Quaternion.identity);
        GameObject bulletTmp1 = Instantiate(bullet, transform.position, Quaternion.identity);
        GameObject bulletTmp2 = Instantiate(bullet, transform.position, Quaternion.identity);
        GameObject bulletTmp3 = Instantiate(bullet, transform.position, Quaternion.identity);

        float angle = Mathf.Atan2(top.y, top.x) * Mathf.Rad2Deg;

        bulletTmp0.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 50));

        Rigidbody2D rb0 = bulletTmp0.GetComponent<Rigidbody2D>();
        Rigidbody2D rb1 = bulletTmp1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bulletTmp2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bulletTmp3.GetComponent<Rigidbody2D>();

        rb0.AddForce(top.normalized * bulletForce, ForceMode2D.Impulse);
        rb1.AddForce(down.normalized * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(left.normalized * bulletForce, ForceMode2D.Impulse);
        rb3.AddForce(right.normalized * bulletForce, ForceMode2D.Impulse);
    }


}
