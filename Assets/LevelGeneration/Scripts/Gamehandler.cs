using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamehandler : MonoBehaviour
{

    // Declare the container of all spawned rooms
    List<GameObject> spawnedRooms = new List<GameObject>();

    // Declare the container of all available slots
    List<GameObject> availableRooms = new List<GameObject>();

    // Declare list of all prefabs that can be spawned
    public GameObject[] roomPrefabs;
    public Transform[] startingPositions;

    // Spawn the first room at 0,0

    // For this and each subsequent room spawn,

    // Check that room's tags for opening type
    // If open above, add (Room.x, Room.y+1, opening down)  to availableRooms
    // If open below, add (Room.x, Room.y-1, opening up)  to availableRooms
    // If open left, add (Room.x-1, Room.y, opening right)  to availableRooms
    // If open left, add (Room.x+1, Room.y, opening left)  to availableRooms

    // Randomly select an element in availableRooms, it will be chosen to spawn in.
    // Randomly select and appropriate room to spawn from roomPrefabs, according to the tag.
    // Add the room to spawnedRooms and remove the room from availableRooms

    // Once the number of rooms to spawn surpasses or is equal to the number of avaialable rooms, add only rooms with 1 exit, so as not to overgenerate.







    public GameObject characterPrefab; // The character prefab you want to spawn.
    public Transform spawnPoint; // The transform of the spawn point.

    

    private GameObject player_;
    private int playerDeaths = 0;
    
    void Start(){

        // Screen should be black..
        // Controls are disabled during loading
        disbaleControls();

        // Generate the dungeon in its entirety
        generateDungeon();

        // Fill dungeon with collectibles
        generateCollectibles();

        // Reset the character
        resetCharacter();
        
        // Spawn the character in
        respawnCharacter();

        // Fade from black to level view
        fadeFromBlack();

        // Enable controls
        enableControls();

        // Gameplay begins...

    }

    
    void Update(){
        
    }

    void disbaleControls(){

    }

    void enableControls(){

    }

    void generateDungeon(){

        // generate the start
        int randStartingPos = Random.Range(0,startingPositions.Length); //randomize the start position
        transform.position = startingPositions[randStartingPos].position; //insert the coordinate of the chosen position
        Instantiate(roomPrefabs[0], transform.position, Quaternion.identity); //place the room or any specific room we want with coordinate and no rotation

        Debug.Log("inital room done");

    }

    void generateCollectibles(){

    }

    void resetCharacter(){

        if (characterPrefab != null && spawnPoint != null)
        {
            player_ = Instantiate(characterPrefab, spawnPoint.position, Quaternion.identity);
            playerDeaths = 0;
        }
        else
        {
            Debug.LogWarning("Character prefab or spawn point is not set!");
        }
    }

    public void playerDeath(){

        // Simple 3 lives mechanic
        if(playerDeaths < 3){

            playerDeaths++;
            Debug.Log(playerDeaths);
            respawnCharacter();

        } else {

            gameOver();
        }
        
    }

    void respawnCharacter(){

        fadeToBlack();
        player_.transform.position = spawnPoint.position;
        fadeFromBlack();

    }

    void gameOver(){

        fadeToBlack();
        Debug.Log("Game Over.");
        fadeFromBlack();

    }

    void fadeFromBlack(){

    }

    void fadeToBlack(){

    }

}
