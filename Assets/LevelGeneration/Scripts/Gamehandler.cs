using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamehandler : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1.0f;


    public Graphic GemRIcon;
    public Graphic GemGIcon;
    public Graphic GemBIcon;

    public float opaqueAlpha = 1.0f; // 1.0 means fully opaque
    public float transparentAlpha = 0.3f; // 0.5 means semi-transparent, adjust as needed

    private bool gemBCollected = false; 
    private bool gemGCollected = false; 
    private bool gemRCollected = false;


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

    public Transform spawnPoint; // The transform of the character respawn point.

    private GameObject player_;
    private int playerDeaths = 0;
    
    void Start(){

        Color newColor = GemRIcon.color;
        newColor.a = transparentAlpha;
        GemRIcon.color = newColor;
        GemGIcon.color = newColor;
        GemBIcon.color = newColor;


        player_ = GameObject.FindWithTag("Player");

        // Screen should be black..

        // Generate the dungeon in its entirety
        
        generateDungeon(3,4,barracksStart,barracksPrefabs);
        generateDungeon(3,6,quartersStart,quartersPrefabs);
        generateDungeon(4,3,dungeonStart,dungeonPrefabs);
        generateDungeon(2,2,keepStart,keepPrefabs);
        generateDungeon(1,5,towerStart,towerPrefabs);
        generateDungeon(2,3,vaultStart,vaultPrefabs);

        // Reset the character
        resetCharacter();
        
        // Spawn the character in
        respawnCharacter();

        // Fade from black to level view
        FadeFromBlack();

        // Gameplay begins...
    }

    void Update(){

    }

    public void collect(string type){
        switch(type){
            case "Coin":
                collectCoin();
                break;
            case "GemR":
                collectGemR();
                break;
            case "GemB":
                collectGemB();
                break;
            case "GemG":
                collectGemG();
                break;
        }
    }

    public void collectGemG(){
        gemGCollected = true;
        Color newColor = GemGIcon.color;
        newColor.a = opaqueAlpha;
        GemGIcon.color = newColor;
    }
    public void collectGemR(){
        gemRCollected = true;
        Color newColor = GemRIcon.color;
        newColor.a = opaqueAlpha;
        GemRIcon.color = newColor;
    }
    public void collectGemB(){
        gemBCollected = true;
        Color newColor = GemBIcon.color;
        newColor.a = opaqueAlpha;
        GemBIcon.color = newColor;
    }
    public void collectCoin(){
        Debug.Log("Coin");
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

    void resetCharacter(){

        playerDeaths = 0;

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

        FadeToBlack();
        player_.transform.position = spawnPoint.position;
        FadeFromBlack();

    }

    void gameOver(){

        FadeToBlack();
        Debug.Log("Game Over.");
        // Load the end screen
        // Button to reset character
        // Button to exit

    }

    public void FadeToBlack()
    {
        StartCoroutine(FadeToBlackRoutine());
    }

    private IEnumerator FadeToBlackRoutine()
    {
        while (fadeImage.color.a < 1.0f)
        {
            Color newColor = fadeImage.color;
            newColor.a += fadeSpeed * Time.deltaTime;
            fadeImage.color = newColor;
            yield return null;
        }
    }

    public void FadeFromBlack()
    {
        StartCoroutine(FadeFromBlackRoutine());
    }

    private IEnumerator FadeFromBlackRoutine()
    {
        while (fadeImage.color.a > 0.0f)
        {
            Color newColor = fadeImage.color;
            newColor.a -= fadeSpeed * Time.deltaTime;
            fadeImage.color = newColor;
            yield return null;
        }
    }

    public void finishTheGame()
    {
        Debug.Log("The game is over");

        #if UNITY_EDITOR
            // In the Unity Editor, stop play mode
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // In a standalone build, quit the application
            Application.Quit();
        #endif
    }

}
