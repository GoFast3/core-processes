using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // ��������� �� �����
    public float smoothSpeed = 0.125f; // ������ ����� �� ������
    public Vector3 offset; // ���� ��� ������ �����

    void Start()
    {
        // ����� ������ �� �� ���� ����� ����
        if (offset == Vector3.zero)
        {
            //offset = (0,2, transform.position - target.position);
            offset = transform.position - target.position;
        }
    }

    void LateUpdate()
    {
        // ����� ����� ��� �� ������
        Vector3 desiredPosition = target.position + offset;

        // ����� ������ ���� ��� ����� ����� ����
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // ����� ������ �� ������
        transform.position = smoothedPosition;

        // ���������: ����� �� ����� ������ ���� �����
        // transform.LookAt(target); 
    }
}
