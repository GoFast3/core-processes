
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
    public float minSpawnDistance = 10f;  // המרחק הקרוב


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
            if (desiredLane < 2)  // תתקן את הבדיקה כך שתהיה נכונה
            {
                desiredLane++;

            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (desiredLane > 0)  // תתקן את הבדיקה כך שתהיה נכונה
            {
                desiredLane--;

            }
        }



        // חישוב המיקום החדש
        UnityEngine.Vector3 targetPosition = transform.position; // קח את המיקום הנוכחי של השחקן

        // שינוי המיקום לפי הנתיב המבוקש
        if (desiredLane == 0)
            targetPosition.x = 0;  // בנתיב 0, המיקום הוא ב-x=0
        else if (desiredLane == 1)
            targetPosition.x = 2;  // בנתיב 1, המיקום הוא ב-x=2
        else if (desiredLane == 2)
            targetPosition.x = 4;  // בנתיב 2, המיקום הוא ב-x=4



        transform.position = targetPosition;  // עדכון המיקום


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