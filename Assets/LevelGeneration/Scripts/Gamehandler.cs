using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamehandler : MonoBehaviour
{

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
