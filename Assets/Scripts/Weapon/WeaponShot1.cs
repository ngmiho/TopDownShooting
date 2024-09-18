using UnityEngine;

public class WeaponShot1 : MonoBehaviour
{
    public GameObject bullet; //lưu trữ bullet
    public Transform[] bulletPositions; //nơi tạo ra bullet - đầu súng
    public float bulletForce;
    public float TimeBtwFire = 0.2f; //tốc độ bắn
    private float cooldown;

    //Effect for shoot
    public GameObject muzzle;
    public GameObject fireEffect;

    public void SetAgi()
    {
        bulletForce = (int)GetComponentInParent<Player>().agi;
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
    }

    public void Shoot0(Vector3 target, int upgradeDamage)
    {
        if (cooldown > 0) return;
        cooldown = TimeBtwFire;

        //upgrade dame
        bullet.GetComponent<DamageRange>().minDamage += upgradeDamage;
        bullet.GetComponent<DamageRange>().maxDamage += upgradeDamage;


        Vector3 mousePos = Camera.main.ScreenToWorldPoint(target);
        Vector2 direction = (mousePos - bulletPositions[0].position).normalized;

        CreateProjectile(direction, 0);
        CreateProjectile(direction, 10);
        CreateProjectile(direction, -10);
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
        rb.AddForce(projectile.transform.right * bulletForce, ForceMode2D.Impulse);

        Destroy(projectile, 0.15f);
    }


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public AudioClip shootSound;
    public AudioSource audioSource;
}
