using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;  // ������ �� �����
    public float initialSpawnDistance = 20f;  // ���� ������ ��� ����� ������ ������
    public float spawnZDistance = 10f;  // ����� ����� ������ ������� ������
    public float distanceBetweenCoins = 5f; // ����� ��� �� ����
    public int laneCount = 3; // ���� �������
    private Transform playerTransform;  // ����� �����
    private float lastSpawnZ = 0f;  // ������ ������ ��� ����� ����

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // ����� ������ ��������
        GenerateInitialCoins();
    }

    void Update()
    {
        // �� ����� ����� ����� ��� ����� ������ ���, ����� ������ �����
        if (playerTransform.position.z > lastSpawnZ - spawnZDistance)
        {
            SpawnCoins();
        }
    }

    void GenerateInitialCoins()
    {
        // ����� ������ ����� ����� �� initialSpawnDistance
        float spawnZ = 0f;
        while (spawnZ < initialSpawnDistance)
        {
            for (int i = 0; i < laneCount; i++)
            {
                // ����� ������� ����� ���� ��� ����
                if (Random.value > 0.8f)  // ����� �� 20% ������ ����
                {
                    Vector3 spawnPosition = new Vector3(i * 2, -0.3f, spawnZ);  // ����� �����
                    Instantiate(coinPrefab, spawnPosition, Quaternion.identity);  // ����� �����
                }
            }
            spawnZ += distanceBetweenCoins;  // ����� ������ ���
        }

        lastSpawnZ = spawnZ;  // ����� ������ ������
    }

    void SpawnCoins()
    {
        // ����� ������ ����� ��������� �����
        float spawnZ = lastSpawnZ + distanceBetweenCoins;

        for (int i = 0; i < laneCount; i++)
        {
            // ����� ������� ����� ���� ��� ����
            if (Random.value > 0.8f)  // ����� �� 20% ������ ����
            {
                Vector3 spawnPosition = new Vector3(i * 2, -0.3f, spawnZ);  // ����� �����
                Instantiate(coinPrefab, spawnPosition, Quaternion.identity);  // ����� �����
            }
        }

        lastSpawnZ = spawnZ;  // ����� ������ ������
    }
}
