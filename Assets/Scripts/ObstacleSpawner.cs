using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float minSpawnDistance = 10f;  // ����� �����
    public float maxSpawnDistance = 80f;  // ����� �����
    public float spawnInterval = 2f;  // ��� ������� ��� ����� ��������
    public float obstacleHeight = -0.5f;  // ���� ������, ���� ����� �� �����
    public int laneCount = 3;  // ���� �������
    public float laneDistance = 2f;  // ����� ��� �� ����

    private float lastSpawnTime;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;  // ���� �����
        minSpawnDistance = PlayerPrefs.GetFloat("minSpawnDistance");
        Debug.Log("distat  start the game whit "+minSpawnDistance);
         lastSpawnTime = Time.time;

       
       
    }

    void Update()
    {
        // �� ���� ���� ����� �����, ����� ����
        if (Time.time - lastSpawnTime > spawnInterval)
        {
            lastSpawnTime = Time.time;
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        // ����� ����� ��� ����� ������ - ���� ����� ����� ����
        float spawnDistance;


            spawnDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
       

        // ����� ������ �� ������
        Vector3 spawnPosition = playerTransform.position + playerTransform.forward * spawnDistance;
        spawnPosition.y = obstacleHeight;  // ����� �� ������ ����� ����� ��

        // ����� ���� ������� ��� 0 �-2 (3 ������)
        int randomLane = Random.Range(0, laneCount);
        spawnPosition.x = randomLane * laneDistance;  // ����� ������� �� ��� �-X ��� �����

        // ����� ������
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }

}
