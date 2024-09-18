using Unity.VisualScripting;
using UnityEngine;

public class WeaponShot0 : MonoBehaviour
{
    public GameObject bullet; //lưu trữ bullet
    public Transform[] bulletPositions; //nơi tạo ra bullet - đầu súng
    public float bulletForce;
    public float TimeBtwFire = 0.2f; //tốc độ bắn
    private float cooldown;

    //Effect for shoot
    public GameObject muzzle;
    public GameObject fireEffect;

    //sound
    public AudioClip shootSound;
    public AudioSource audioSource;

    public void SetAgi()
    {
        bulletForce = (int)GetComponentInParent<Player>().agi;
    }

    void Start()
    {
        //str
        bulletForce = (int)GetComponentInParent<Player>().agi;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
    }

    public void Shoot0(Vector3 target)
    {
        if (cooldown > 0) return;
        cooldown = TimeBtwFire;

        GameObject bulletTmp0;

        if (bulletPositions.Length > 0)
        {
            //                                 GameObject   position             rotation
            bulletTmp0 = Instantiate(bullet, bulletPositions[0].position, Quaternion.identity);
        }
        else
        {
            bulletTmp0 = Instantiate(bullet, transform.position, Quaternion.identity);
        }

        //status - str
        bulletTmp0.GetComponent<DamageRange>().minDamage = (int)GetComponentInParent<Player>().str;
        bulletTmp0.GetComponent<DamageRange>().maxDamage = (int)GetComponentInParent<Player>().str;

        //Effect for Shoot
        if (!muzzle.IsUnityNull())
        {
            GameObject m = Instantiate(muzzle, bulletPositions[0].position, transform.rotation, transform);
            Destroy(m, 0.1f);
        }
        if (!fireEffect.IsUnityNull())
        {
            GameObject f = Instantiate(fireEffect, bulletPositions[0].position, transform.rotation, transform);
            Destroy(f, 0.1f);
        }

        Rigidbody2D rb0 = bulletTmp0.GetComponent<Rigidbody2D>();
        //               hướng vector * lực           chế độ lực - impulse
        rb0.AddForce((target - transform.position).normalized * bulletForce, ForceMode2D.Impulse);

        audioSource.PlayOneShot(shootSound);
    }


    public void Shoot1(Vector3 target)
    {
        if (cooldown > 0) return;
        cooldown = TimeBtwFire;

        GameObject bulletTmp1 = Instantiate(bullet, bulletPositions[1].position, Quaternion.identity);
        GameObject bulletTmp2 = Instantiate(bullet, bulletPositions[2].position, Quaternion.identity);

        //status - str
        bulletTmp1.GetComponent<DamageRange>().minDamage = (int)GetComponentInParent<Player>().str;
        bulletTmp1.GetComponent<DamageRange>().maxDamage = (int)GetComponentInParent<Player>().str;
        bulletTmp2.GetComponent<DamageRange>().minDamage = (int)GetComponentInParent<Player>().str;
        bulletTmp2.GetComponent<DamageRange>().maxDamage = (int)GetComponentInParent<Player>().str;

        if (!muzzle.IsUnityNull())
        {
            GameObject m = Instantiate(muzzle, bulletPositions[0].position, transform.rotation, transform);
            Destroy(m, 0.1f);
        }
        if (!fireEffect.IsUnityNull())
        {
            GameObject f = Instantiate(fireEffect, bulletPositions[0].position, transform.rotation, transform);
            Destroy(f, 0.1f);
        }

        Rigidbody2D rb1 = bulletTmp1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bulletTmp2.GetComponent<Rigidbody2D>();

        rb1.AddForce((target - transform.position).normalized * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce((target - transform.position).normalized * bulletForce, ForceMode2D.Impulse);

        audioSource.PlayOneShot(shootSound);
    }

    //public void Shoot2(Vector3 target)
    //{
    //    if (cooldown > 0) return;
    //    cooldown = TimeBtwFire;

    //    GameObject bulletTmp3 = Instantiate(bullet, bulletPositions[3].position, Quaternion.identity);
    //    GameObject bulletTmp4 = Instantiate(bullet, bulletPositions[4].position, Quaternion.identity);
    //    GameObject bulletTmp5 = Instantiate(bullet, bulletPositions[5].position, Quaternion.identity);


    //    Rigidbody2D rb3 = bulletTmp3.GetComponent<Rigidbody2D>();
    //    Rigidbody2D rb4 = bulletTmp4.GetComponent<Rigidbody2D>();
    //    Rigidbody2D rb5 = bulletTmp5.GetComponent<Rigidbody2D>();

    //    Vector3 targetLeft = target;
    //    Vector3 targetRight = target;

    //    targetLeft = Quaternion.Euler(0, 0, bulletTmp4.transform.eulerAngles.z + 40);

    //    rb3.AddForce(target.normalized * bulletForce, ForceMode2D.Impulse);
    //    rb4.AddForce(targetLeft.normalized * bulletForce, ForceMode2D.Impulse);
    //    rb5.AddForce(targetRight.normalized * bulletForce, ForceMode2D.Impulse);

    //    audioSource.PlayOneShot(shootSound);
    //}

    public void Shoot2(Vector3 target)
    {
        if (cooldown > 0) return;
        cooldown = TimeBtwFire;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(target);
        Vector2 direction = (mousePos - bulletPositions[0].position).normalized;

        CreateProjectile(direction, 0);
        CreateProjectile(direction, 15);
        CreateProjectile(direction, -15);
    }

    void CreateProjectile(Vector2 direction, float angleOffset)
    {
        GameObject projectile = Instantiate(bullet, bulletPositions[0].position, Quaternion.identity);
        //status - str
        projectile.GetComponent<DamageRange>().minDamage = (int)GetComponentInParent<Player>().str;
        projectile.GetComponent<DamageRange>().maxDamage = (int)GetComponentInParent<Player>().str;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + angleOffset));
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (!muzzle.IsUnityNull())
        {
            GameObject m = Instantiate(muzzle, bulletPositions[0].position, transform.rotation, transform);
            Destroy(m, 0.1f);
        }
        if (!fireEffect.IsUnityNull())
        {
            GameObject f = Instantiate(fireEffect, bulletPositions[0].position, transform.rotation, transform);
            Destroy(f, 0.1f);
        }

        rb.AddForce(projectile.transform.right * bulletForce, ForceMode2D.Impulse);
    }

}
