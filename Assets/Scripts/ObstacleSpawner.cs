using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float minSpawnDistance = 10f;  // המרחק הקרוב
    public float maxSpawnDistance = 80f;  // המרחק הרחוק
    public float spawnInterval = 2f;  // זמן רנדומלי בין יצירת המכשולים
    public float obstacleHeight = -0.5f;  // גובה המכשול, ניתן לשלוט בו מבחוץ
    public int laneCount = 3;  // מספר הנתיבים
    public float laneDistance = 2f;  // המרחק בין כל נתיב

    private float lastSpawnTime;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;  // השגת השחקן
        minSpawnDistance = PlayerPrefs.GetFloat("minSpawnDistance");
        Debug.Log("distat  start the game whit "+minSpawnDistance);
         lastSpawnTime = Time.time;

       
       
    }

    void Update()
    {
        // אם הגיע הזמן ליצור מכשול, ניצור אותו
        if (Time.time - lastSpawnTime > spawnInterval)
        {
            lastSpawnTime = Time.time;
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        // קביעת המרחק שבו יופיע המכשול - יותר סיכוי למרחק רחוק
        float spawnDistance;


            spawnDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
       

        // קביעת המיקום של המכשול
        Vector3 spawnPosition = playerTransform.position + playerTransform.forward * spawnDistance;
        spawnPosition.y = obstacleHeight;  // הגובה של המכשול שניתן לשלוט בו

        // לבחור נתיב רנדומלי בין 0 ל-2 (3 נתיבים)
        int randomLane = Random.Range(0, laneCount);
        spawnPosition.x = randomLane * laneDistance;  // מיקום רנדומלי על ציר ה-X לפי הנתיב

        // יצירת המכשול
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }

}
