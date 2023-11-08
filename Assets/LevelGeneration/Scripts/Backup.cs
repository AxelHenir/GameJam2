using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backup : MonoBehaviour
{
   using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Declare the container of all spawned rooms
    List<GameObject> spawnedRooms = new List<GameObject>();

    // Declare the container of all available slots
    List<GameObject> availableRooms = new List<GameObject>();

    // Declare list of all prefabs that can be spawned
    public GameObject[] roomPrefabs;

    
    
    // Spawn the first room at 0,0
    void Start()
    {
        // Spawn the first room at (0, 0) and add it to spawnedRooms
        GameObject firstRoom = Instantiate(roomPrefabs[0], Vector2.zero, Quaternion.identity);
        spawnedRooms.Add(firstRoom);

        // Add the adjacent rooms to availableRooms
        AddAdjacentRooms(Vector2.zero, firstRoom);
    }

    // Function to add adjacent rooms to availableRooms
    void AddAdjacentRooms(Vector2 position, GameObject room)
    {
        // Check if the room has openings in each direction
        if (room.CompareTag("OpenAbove"))
        {
            Vector2 abovePosition = position + Vector2.up;
            AddRoomToAvailable(abovePosition, "OpeningDown");
        }
        if (room.CompareTag("OpenBelow"))
        {
            Vector2 belowPosition = position + Vector2.down;
            AddRoomToAvailable(belowPosition, "OpeningUp");
        }
        if (room.CompareTag("OpenLeft"))
        {
            Vector2 leftPosition = position + Vector2.left;
            AddRoomToAvailable(leftPosition, "OpeningRight");
        }
        if (room.CompareTag("OpenRight"))
        {
            Vector2 rightPosition = position + Vector2.right;
            AddRoomToAvailable(rightPosition, "OpeningLeft");
        }
    }

    // Function to add a room to availableRooms
    void AddRoomToAvailable(Vector2 position, string tag)
    {
        // Check if a room already exists at the given position
        if (availableRooms.Exists(room => (Vector2)room.transform.position == position))
            return;

        // Find a suitable prefab to spawn based on the tag
        GameObject roomPrefab = FindRoomPrefabByTag(tag);

        if (roomPrefab != null)
        {
            GameObject room = Instantiate(roomPrefab, position, Quaternion.identity);
            availableRooms.Add(room);
        }
    }

    // Function to find a room prefab by tag
    GameObject FindRoomPrefabByTag(string tag)
    {
        foreach (GameObject prefab in roomPrefabs)
        {
            if (prefab.CompareTag(tag))
            {
                return prefab;
            }
        }
        return null;
    }
}
}
