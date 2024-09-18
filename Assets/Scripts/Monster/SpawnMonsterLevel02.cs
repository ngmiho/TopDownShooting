using System.Collections;
using UnityEngine;

public class SpawnMonsterLevel02 : MonoBehaviour
{
    public GameObject Monster1;
    public GameObject Monster2;

    //count monster
    private int monsterNumber = 0;
    public int countMonster;
    public int countBoss;

    //UI
    public Monster monster;

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

        StartCoroutine(SpawnMonster());
    }

    private IEnumerator SpawnMonster()
    {
        while (monsterNumber < 30)
        {
            float x = RandomX();
            float y = RandomY();
            int random = Random.Range(0, 1);
            switch (random)
            {
                case 0:
                    Instantiate(Monster1, new Vector3(positionX + prefixX, Random.Range(positionY + prefixY, positionY + suffixY), -1), Quaternion.identity);
                    monster.UpdateMonster(50);
                    Instantiate(Monster2, new Vector3(positionX + suffixX, Random.Range(positionY + prefixY, positionY + suffixY), -1), Quaternion.identity);
                    monster.UpdateMonster(50);
                    //count monster
                    monsterNumber += 2;
                    yield return new WaitForSeconds(5f);
                    break;
                case 1:
                    Instantiate(Monster1, new Vector3(Random.Range(positionX + prefixX, positionX + suffixX), positionY + prefixY, -1), Quaternion.identity);
                    monster.UpdateMonster(50);
                    Instantiate(Monster2, new Vector3(Random.Range(positionX + prefixX, positionX + suffixX), positionY + suffixY, -1), Quaternion.identity);
                    monster.UpdateMonster(50);
                    //count monster
                    monsterNumber += 2;
                    yield return new WaitForSeconds(5f);
                    break;
            }
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
