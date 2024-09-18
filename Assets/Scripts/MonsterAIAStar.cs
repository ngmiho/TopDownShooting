using Pathfinding;
using System.Collections;
using UnityEngine;

public class MonsterAIAStar : MonoBehaviour
{
    public float moveSpeed;
    public float nextWPDistance;
    public Seeker seeker;
    public SpriteRenderer characterSR;
    Transform target;
    Path path; //đường monster đi theo

    Coroutine moveCoroutine; //đính kèm với GameObject

    private void Start()
    {
        //biết được vị trí của Player
        target = FindObjectOfType<Player>().gameObject.transform;

        InvokeRepeating("CalculatePath", 0f, 0.5f);
    }

    void CalculatePath()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance < 5f)
            GetComponent<MonsterManager>().animator.SetFloat("Attack", 1f);
        else
            GetComponent<MonsterManager>().animator.SetFloat("Attack", 0f);

        if (seeker.IsDone()) //check tránh trùng path
            seeker.StartPath(transform.position, target.position, OnPathCallback);
    }

    void OnPathCallback(Path p)
    {
        if (p.error) return;

        path = p;
        //Move to target
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }

    IEnumerator MoveToTargetCoroutine()
    {
        //way point
        int currentWP = 0;

        while (currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector3 force = direction * moveSpeed * Time.deltaTime;
            transform.position += force;

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWPDistance)
                currentWP++;

            if (force.x != 0)
                if (force.x < 0)
                    characterSR.transform.localScale = new Vector3(-1, 1, 0);
                else
                    characterSR.transform.localScale = new Vector3(1, 1, 0);

            //yield return new WaitForSeconds(0.5f); //thực hiện mỗi 2 giây thực hiện 1 lần
            yield return null; //thực hiện mỗi frame
        }
    }

}
