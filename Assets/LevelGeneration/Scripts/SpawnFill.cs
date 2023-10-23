using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFill : MonoBehaviour
{
    public LayerMask whatIsRoom;
    public LevelGenBaracks levelGen;
  
    void Update()
    {
        //checking if a room was already generating
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom); 
        if(roomDetection == null &&levelGen.stopGeneration == true) //if there is no room
        {
            //Spawn a random room
            int rand = Random.Range(0, levelGen.rooms.Length);
            Instantiate(levelGen.rooms[rand], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
