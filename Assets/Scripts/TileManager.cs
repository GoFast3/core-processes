using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs; // ���� �� ������� ��� ���� ������
    private List<GameObject> activeTiles = new List<GameObject>(); // ����� �� ����� ������ �����
    public float tileLength = 30f; // ���� �� ���
    public int numberOfTiles = 5; // ���� ������ ������� ��� ���
    private float zSpawn = 0; // ������ ������ ���� Z ������ ��� ���
    public Transform playerTransform; // Transform �� �����

    private void Start()
    {
        // ����� ����� ��������
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0); // ����� ��� ����� ����
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length)); // ����� ����� �������
        }
    }

    private void Update()
    {
        // ����� �� �� ���� ������ ������ �����
        if (playerTransform.position.z - 35 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length)); // ����� ��� ���
            DeleteTile(); // ����� ���� ���� �����
        }
    }

    private void SpawnTile(int tileIndex)
    {
        // ����� ��� ���
        GameObject newTile = Instantiate(tilePrefabs[tileIndex], new Vector3(0, 0, zSpawn), Quaternion.identity);
        activeTiles.Add(newTile); // ����� ���� ������ ������ �������
        zSpawn += tileLength; // ����� ������ ��� ������ ���
    }

    private void DeleteTile()
    {
        // ����� ���� ���� �����
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
