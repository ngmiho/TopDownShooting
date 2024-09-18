using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    private float time = 0;
    private void Update()
    {
        time += Time.deltaTime;
        if (time < 0.2)
        {
            transform.localPosition += new Vector3(0, 0.001f, 0);
            transform.localScale += new Vector3(0.0001f, 0.0001f, 0.0001f);
        }
        else
        {
            transform.localPosition -= new Vector3(0, 0.001f, 0);
            transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
        }

    }
}
