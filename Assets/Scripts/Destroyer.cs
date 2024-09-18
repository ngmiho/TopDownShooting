using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float Time;
    private void Update()
    {
        Destroy(this.gameObject, Time);
    }
}
