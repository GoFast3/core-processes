using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // הטרנספורם של השחקן
    public float smoothSpeed = 0.125f; // מהירות החלקה של המצלמה
    public Vector3 offset; // מרחק בין המצלמה לשחקן

    void Start()
    {
        // חישוב האופסט אם לא הוזן באופן ידני
        if (offset == Vector3.zero)
        {
            //offset = (0,2, transform.position - target.position);
            offset = transform.position - target.position;
        }
    }

    void LateUpdate()
    {
        // חישוב מיקום חדש של המצלמה
        Vector3 desiredPosition = target.position + offset;

        // החלקה למיקום החדש כדי ליצור תנועה חלקה
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // עדכון המיקום של המצלמה
        transform.position = smoothedPosition;

        // אופציונלי: שמירה על זווית המצלמה לעבר השחקן
        // transform.LookAt(target); 
    }
}
