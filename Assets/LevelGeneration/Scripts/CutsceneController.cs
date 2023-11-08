using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Play the cutscene
        // Once complete, go to next scene
    }

    public void StartGameplay()
    {
        // Load the next scene
        SceneManager.LoadScene("MainGame");
    }



    
}
