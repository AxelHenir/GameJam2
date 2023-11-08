using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamehandler : MonoBehaviour
{

    public GameObject[] barracksPrefabs; // An array of room prefabs to choose from.
    public GameObject[] quartersPrefabs; // An array of room prefabs to choose from.
    public GameObject[] dungeonPrefabs; // An array of room prefabs to choose from.
    public GameObject[] keepPrefabs; // An array of room prefabs to choose from.
    public GameObject[] towerPrefabs; // An array of room prefabs to choose from.
    public GameObject[] vaultPrefabs; // An array of room prefabs to choose from.

    public Transform barracksStart;
    public Transform quartersStart;
    public Transform dungeonStart;
    public Transform keepStart;
    public Transform towerStart;
    public Transform vaultStart;


    public GameObject characterPrefab; // The character prefab you want to spawn.
    public Transform spawnPoint; // The transform of the spawn point.

    

    private GameObject player_;
    private int playerDeaths = 0;
    
    void Start(){

        // Screen should be black..
        // Controls are disabled during loading
        disbaleControls();

        // Generate the dungeon in its entirety

        generateDungeon(3,4,barracksStart,barracksPrefabs);
        generateDungeon(3,6,quartersStart,quartersPrefabs);
        generateDungeon(4,3,dungeonStart,dungeonPrefabs);
        generateDungeon(2,2,keepStart,keepPrefabs);
        generateDungeon(1,5,towerStart,towerPrefabs);
        generateDungeon(2,3,vaultStart,vaultPrefabs);
       

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
                Vector3 spawnPosition = new Vector3(rootPosition.position.x + x * 32, rootPosition.position.y + y * 18, 0);
                int randomRoomIndex = Random.Range(0, roomPrefabs.Length);
                GameObject randomRoomPrefab = roomPrefabs[randomRoomIndex];
                Instantiate(randomRoomPrefab, spawnPosition, Quaternion.identity);
            }
        }

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
