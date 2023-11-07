using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPairController : MonoBehaviour
{
    public Transform destinationDoor; // The other door in the pair

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
            TeleportPlayer();
        }
    }

    private void TeleportPlayer()
    {
        if (destinationDoor != null)
        {
            // Teleport the player to the destination door's position
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = destinationDoor.position;
        }
    }
}

