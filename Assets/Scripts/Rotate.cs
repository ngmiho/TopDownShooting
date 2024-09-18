using UnityEngine;

public class Rotate : MonoBehaviour
{
    public void RotateByVector3OfGameObject(Vector3 target)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(target);
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; //lấy được gốc hệ Radian convert to Degree

        Quaternion rotation = Quaternion.Euler(0, 0, angle); //Unity sử dụng Quaternion ?? ?i?u ch?nh h??ng thay cho Rotation
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            transform.localScale = new Vector3(1, -1, 0);
        else
            transform.localScale = new Vector3(1, 1, 0);
    }
}
