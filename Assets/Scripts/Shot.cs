using Unity.VisualScripting;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject bullet; //lưu trữ bullet
    public Transform[] bulletPositions; //nơi tạo ra bullet - đầu súng
    public float bulletForce;
    public float TimeBtwFire = 0.2f; //tốc độ bắn
    private float cooldown;

    //Effect for shoot
    public GameObject muzzle;
    public GameObject fireEffect;


    private void Update()
    {
        cooldown -= Time.deltaTime;
    }

    public void Shoot(Vector3 target)
    {
        if (cooldown > 0) return;
        cooldown = TimeBtwFire;

        GameObject bulletTmp0;
        if (bulletPositions.Length > 0)
        {
            //                                 GameObject   position             rotation
            bulletTmp0 = Instantiate(bullet, bulletPositions[0].position, Quaternion.identity);
            //GameObject bulletTmp1 = Instantiate(bullet, bulletPositions[1].position, Quaternion.identity);
            //GameObject bulletTmp2 = Instantiate(bullet, bulletPositions[2].position, Quaternion.identity);
        }
        else
        {
            bulletTmp0 = Instantiate(bullet, transform.position, Quaternion.identity);
        }


        //Effect for Shoot
        //                                       theo hướng của cây súng
        if (!muzzle.IsUnityNull())
        {
            GameObject m = Instantiate(muzzle, bulletPositions[0].position, transform.rotation, transform);
            //Instantiate(muzzle, bulletPositions[1].position, transform.rotation, transform);
            //Instantiate(muzzle, bulletPositions[2].position, transform.rotation, transform);
            //Destroy(m, 0.1f);
        }
        if (!fireEffect.IsUnityNull())
        {
            GameObject f = Instantiate(fireEffect, bulletPositions[0].position, transform.rotation, transform);
            //Instantiate(fireEffect, bulletPositions[1].position, transform.rotation, transform);
            //Instantiate(fireEffect, bulletPositions[2].position, transform.rotation, transform);
            //Destroy(f, 0.1f);
        }

        //thêm force
        Rigidbody2D rb0 = bulletTmp0.GetComponent<Rigidbody2D>();
        //Rigidbody2D rb1 = bulletTmp1.GetComponent<Rigidbody2D>();
        //Rigidbody2D rb2 = bulletTmp2.GetComponent<Rigidbody2D>();
        //               hướng vector * lực           chế độ lực - impulse - thêm lực 1 lần khi bắn ra
        rb0.AddForce(target.normalized * bulletForce, ForceMode2D.Impulse);
        //rb1.AddForce(target.normalized * bulletForce, ForceMode2D.Impulse);
        //rb2.AddForce(target.normalized * bulletForce, ForceMode2D.Impulse);
    }
}
