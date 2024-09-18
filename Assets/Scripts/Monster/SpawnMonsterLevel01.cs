using System.Collections;
using UnityEngine;

public class SpawnMonsterLevel01 : MonoBehaviour
{
    public GameObject Monster1;
    public GameObject Monster2;
    public GameObject Boss1;

    //count monster
    private int monsterNumber = 0;
    public int countMonster;
    public int countBoss;

    //UI
    public Monster monster;

    //player - position 
    public float positionX;
    public float positionY;


    private void Start()
    {
        positionX = FindObjectOfType<Player>().gameObject.transform.localPosition.x;
        positionY = FindObjectOfType<Player>().gameObject.transform.localPosition.y;

        StartCoroutine(SpawnMonster());
    }

    public int prefixX = -12;
    public int suffixX = 12;
    public int prefixY = -6;
    public int suffixY = 6;
    private IEnumerator SpawnMonster()
    {
        while (monsterNumber < 20)
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


    //private void Update()
    //{
    //    //countMonster = int.Parse(transform.GetChild(2).GetComponent<TextMeshProUGUI>().text);
    //    //countBoss = int.Parse(transform.GetChild(3).GetComponent<TextMeshProUGUI>().text);

    //    ////dialog route
    //    //if (countRoute == countBoss)
    //    //{
    //    //    Instantiate(DialogRoutes[countRoute], transform.position, Quaternion.identity);
    //    //    ++countRoute;
    //    //}

    //    //spawn monster
    //    if (monsterNumber < 20)
    //    {
    //        float a = RandomNumber();
    //        float b = RandomNumber();
    //        if (a < 20 || a > 30)
    //        {
    //            if (-b < -30 || -b > -20)
    //            {
    //                Instantiate(Monster1, new Vector3(a, -b, -1), Quaternion.identity);
    //                monster.UpdateMonster(50);
    //                Instantiate(Monster2, new Vector3(b, -a, -1), Quaternion.identity);
    //                //count monster
    //                monsterNumber += 2;
    //                monster.UpdateMonster(50);
    //            }
    //        }
    //    }

    //    //spawn boss
    //    if (countMonster == 20)
    //    {
    //        float c = RandomNumber();
    //        float d = RandomNumber();
    //        Instantiate(Boss1, new Vector3(c, -d, -1), Quaternion.identity);
    //        //isBoss = false;
    //        FindObjectOfType<SpawnMonsterLevel01>().gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "0";
    //    }

    //    ////clear count
    //    //if (countBoss == countRoute)
    //    //{
    //    //    Debug.Log("test2");
    //    //    FindObjectOfType<SpawnMonsterLevel01>().gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "0";
    //    //    FindObjectOfType<SpawnMonsterLevel01>().gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "0";
    //    //    //FindObjectOfType<SpawnMonsterLevel01>().gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "0";
    //    //    monsterNumber = 0;
    //    //    //++countRoute;
    //    //}
    //}

    //private IEnumerator SpawnMonster0()
    //{
    //    while (true)
    //    {
    //        if (monsterNumber <= 20 && !isBoss)
    //        {
    //            float a = RandomNumber();
    //            float b = RandomNumber();
    //            if (a < 20 || a > 30)
    //            {
    //                if (-b < -30 || -b > -20)
    //                {
    //                    Instantiate(Monster1, new Vector3(a, -b, -1), Quaternion.identity);
    //                    ++monsterNumber;
    //                    monster.UpdateMonster(50);
    //                    Instantiate(Monster2, new Vector3(b, -a, -1), Quaternion.identity);
    //                    ++monsterNumber;
    //                    monster.UpdateMonster(50);
    //                    yield return new WaitForSeconds(2f);
    //                }
    //            }
    //        }

    //        if (monsterNumber == 20)
    //        {
    //            float c = RandomNumber();
    //            float d = RandomNumber();
    //            Instantiate(Boss1, new Vector3(c, -d, -1), Quaternion.identity);
    //            isBoss = true;
    //            monsterNumber = 0;
    //        }
    //    }

    //}
}
