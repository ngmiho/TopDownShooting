using UnityEngine;

public class Circle : MonoBehaviour
{
    void Update()
    {
        //Vector3 mouse = Camera.main.WorldToScreenPoint(Input.mousePosition);
        //transform.position = new Vector3(mouse.x, mouse.y, 0);

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        transform.position = mouse;
    }
}
