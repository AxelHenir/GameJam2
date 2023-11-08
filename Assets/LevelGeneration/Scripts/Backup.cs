using UnityEngine;

public class RandomRoomGridSpawner : MonoBehaviour
{
    public GameObject[] roomPrefabs; // An array of room prefabs to choose from.
    public int gridWidth = 5;        // Number of columns.
    public int gridHeight = 5;       // Number of rows.

    void Start()
    {
        SpawnRandomRoomGrid();
    }

    void SpawnRandomRoomGrid()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 spawnPosition = new Vector3(x * 32, y * 18, 0);
                int randomRoomIndex = Random.Range(0, roomPrefabs.Length);
                GameObject randomRoomPrefab = roomPrefabs[randomRoomIndex];
                Instantiate(randomRoomPrefab, spawnPosition, Quaternion.identity, transform);
            }
        }
    }
}
