
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController1 : MonoBehaviour
{
    private CharacterController controller;
    private UnityEngine.Vector3 direction;
    public float forwardSpeed;
    private int desiredLane = 0;
    public float laneDistance = 2;
    public float JumpForce;
    public float Gravity = -20;
    private Touch touch;
    private UnityEngine.Vector2 initPos;
    private UnityEngine.Vector2 endPos;
    public float minSpawnDistance = 10f;  // ����� �����


    void Start()
    {
        controller = GetComponent<CharacterController>();
        Debug.Log("speadPrabf " + PlayerPrefs.GetFloat("forwardSpeed"));
        Debug.Log("mindistance " + PlayerPrefs.GetFloat("minSpawnDistance"));
        forwardSpeed = PlayerPrefs.GetFloat("forwardSpeed");
        minSpawnDistance = PlayerPrefs.GetFloat("minSpawnDistance");


    }




    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;
        direction.y += Gravity * Time.deltaTime;

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (desiredLane < 2)  // ���� �� ������ �� ����� �����
            {
                desiredLane++;

            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (desiredLane > 0)  // ���� �� ������ �� ����� �����
            {
                desiredLane--;

            }
        }



        // ����� ������ ����
        UnityEngine.Vector3 targetPosition = transform.position; // �� �� ������ ������ �� �����

        // ����� ������ ��� ����� ������
        if (desiredLane == 0)
            targetPosition.x = 0;  // ����� 0, ������ ��� �-x=0
        else if (desiredLane == 1)
            targetPosition.x = 2;  // ����� 1, ������ ��� �-x=2
        else if (desiredLane == 2)
            targetPosition.x = 4;  // ����� 2, ������ ��� �-x=4



        transform.position = targetPosition;  // ����� ������


        controller.center = controller.center;

    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = JumpForce;

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "obstacle")
        {
            PlayerManager.gameOver = true;
        }


    }
}