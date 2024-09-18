using UnityEngine;

public class SpawnBossLevel02 : MonoBehaviour
{
    public GameObject Boss2;

    //player - position 
    public float positionX;
    public float positionY;

    public int prefixX = -12;
    public int suffixX = 12;
    public int prefixY = -6;
    public int suffixY = 6;


    private void Start()
    {
        positionX = FindObjectOfType<Player>().gameObject.transform.localPosition.x;
        positionY = FindObjectOfType<Player>().gameObject.transform.localPosition.y;

        SpawnMonster();
    }

    private void SpawnMonster()
    {
        if (Boss2 != null)
        {
            float c = RandomX();
            float d = RandomX();
            Instantiate(Boss2, new Vector3(c, -d, -1), Quaternion.identity);
        }
    }

    private float RandomX()
    {
        return Random.Range(prefixX, suffixX);
    }
    private float RandomY()
    {
        return Random.Range(prefixY, suffixY);
    }
}
