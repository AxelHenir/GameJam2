using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    // Triggered when a GameObject enters the trigger zone of the spike
    private void OnTriggerEnter2D(Collider2D collider)
    {

        Debug.Log("Collision detected");

        // Check if the player is colliding and moving into the spike
        if (collider.CompareTag("Player"))
        {
            // Get the Rigidbody2D component of the player
            Rigidbody2D playerRigidbody = collider.GetComponent<Rigidbody2D>();

            // Check the vertical velocity of the player
            float playerVerticalVelocity = playerRigidbody.velocity.y;

            // Assuming a negative vertical velocity means the player is moving upwards
            if (playerVerticalVelocity <= 0)
            {
            // Player is moving downwards, so apply the spike effect
            GameObject gameHandlerObject = GameObject.Find("GameHandler");
            Gamehandler gameHandler = gameHandlerObject.GetComponent<Gamehandler>();
            gameHandler.playerDeath();
            }
        }
    }
}
