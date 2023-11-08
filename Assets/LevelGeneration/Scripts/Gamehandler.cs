using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamehandler : MonoBehaviour
{

    public GameObject[] barracksPrefabs; // An array of room prefabs to choose from.
    public GameObject[] quartersPrefabs; // An array of room prefabs to choose from.

    public Transform[] startingPositions;
    public Transform[] endPositions;


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

    void generateDungeon(int gridWidth, int gridHeight, Transform rootPosition, GameObject[] roomPrefabs){

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 spawnPosition = new Vector3(rootPosition.x * 32, rootPosition.y * 18, 0);
                int randomRoomIndex = Random.Range(0, roomPrefabs.Length);
                GameObject randomRoomPrefab = roomPrefabs[randomRoomIndex];
                Instantiate(randomRoomPrefab, spawnPosition, Quaternion.identity, transform);
            }
        }

        // generate the start
        // int randStartingPos = Random.Range(0,startingPositions.Length); //randomize the start position
        // transform.position = startingPositions[randStartingPos].position; //insert the coordinate of the chosen position
        // Instantiate(roomPrefabs[0], transform.position, Quaternion.identity); //place the room or any specific room we want with coordinate and no rotation

        // Debug.Log("inital room done");

        // int randEndPos = Random.Range(0, endPositions.Length); //randomize the start position
        // transform.position = endPositions[randEndPos].position; //insert the coordinate of the chosen position
        // Instantiate(roomPrefabs[1], transform.position, Quaternion.identity); //place the room or any specific room we want with coordinate and no rotation

        // Debug.Log("end room done");


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
