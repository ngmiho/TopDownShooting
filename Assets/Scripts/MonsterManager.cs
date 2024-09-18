using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public HPDrop HPDrop;
    public CoinDrop CoinDrop;

    //animation
    public Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (GetComponent<MonsterShot>())
        {
            float distance = Vector3.Distance(FindObjectOfType<Player>().transform.position, transform.position);
            if (distance < 5f)
            {
                //Shoot
                Vector3 direction = FindObjectOfType<Player>().transform.position - transform.position;
                GetComponent<MonsterShot>().Shoot(direction);
            }
        }
    }

    //animation - destroy
    public GameObject MonsterDestroy;
    private void OnDestroy()
    {
        //animation - destroy
        if (MonsterDestroy != null)
            Instantiate(MonsterDestroy, transform.position, Quaternion.identity);

        int randomeNumber = Random.Range(0, 7);
        if (randomeNumber == 1 || randomeNumber == 2)
            CoinDrop.Drop(transform.position);
        else if (randomeNumber == 3 || randomeNumber == 4)
            HPDrop.Drop(transform.position);
    }


}
