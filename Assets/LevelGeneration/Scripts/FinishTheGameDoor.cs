using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTheGameDoor : MonoBehaviour
{
    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            FinishTheGame();
        }
    }

    private void FinishTheGame()
    {
        GameObject gameHandlerObject = GameObject.Find("GameHandler");
        Gamehandler gameHandler = gameHandlerObject.GetComponent<Gamehandler>();
        gameHandler.finishTheGame();
    }
}
