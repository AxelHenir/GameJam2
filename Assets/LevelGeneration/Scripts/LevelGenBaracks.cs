using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenBaracks : MonoBehaviour
{
    public Transform[] startingPositions; //array containing the start position coordinate
    public GameObject[] rooms; //array containing the different room it can use
                               //index 0 --> LR index 1 --> LRB index 2 --> LRT index 3 --> LRTB
    public float moveAmountX; //nb of units between the spawn coordinate in X
    public float moveAmountY; //nb of units between the spawn coordinate in Y

    //boundaries calculates the middle of the level for ref
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public bool stopGeneration;

    public LayerMask room; //fofr destroying the room
   

    // time between spawning room
    private float timeBtwRoom;
    public float startTimeBtwRoom = 0.25f; 


    private int direction; //store the direction going
    private int downCounter; //for making sure the room we go down twice has 4 opening


    

    private void Start()
    {

        int randStartingPos = Random.Range(0, startingPositions.Length); //randomize the start position
        transform.position = startingPositions[randStartingPos].position; //insert the coordinate of the chosen position
        Instantiate(rooms[0], transform.position, Quaternion.identity); //place the room 0 with coordinate and no rotation

        direction = Random.Range(1, 6); //chose a direction to continue the generation 


    }

    private void Update()
    { 
        if (timeBtwRoom <= 0 && stopGeneration == false) 
        {
            Move();
            timeBtwRoom = startTimeBtwRoom;
        } else {
            timeBtwRoom -= Time.deltaTime;
        }
    }

    private void Move()
    {
        if (direction == 1 || direction == 2) //Move Right
        {
            if (transform.position.x < maxX) //check if still inbound
            {
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x + moveAmountX, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6); // making sure it does not go back

                if (direction == 3) //does not move left
                {
                    direction = 2; //change it to right 

                } else if (direction == 4) // does not move left 
                {
                    direction = 5; //change it to down
                }

            }else {  //go down 
            
                direction = 5;
            }
            

        } else if (direction == 3|| direction == 4) //Move Left
        {
            if (transform.position.x > minX)//check if still inbound
            {
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x - moveAmountX, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6);// making sure it does not go back

            }
            else { //go down  
            
                direction = 5;
            }

        } else if (direction == 5) //move down 
        {
            downCounter++; //keep track of the time it went down

            if (transform.position.y > minY)//check if still inbound
            {

                //make a circle collider that checks the room that will be made and if it doesnt have a bottom opening it destroyes it and replace one with an opening
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1,room);
                if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3)
                {
                    if (downCounter >= 2) //if two times down auto make a 4 room
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                    } else
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        int randBottomRoom = Random.Range(1, 4);
                        if (randBottomRoom == 2)
                        {
                            randBottomRoom = 1;
                        }
                        Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                    }
                   


                }
                
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmountY);
                transform.position = newPos;

                int rand = Random.Range(2, 4);
                if (transform.position.y == minY) //if it's the last room at the bottom
                {
                    rand = 1; //tell which specific room to spawn
                }
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);// making sure it does not go back
            }
            else {
                //Stop level generation
                stopGeneration = true;
            }
          

        }



    }

    private void DisableBox()
    {

        GameObject.FindGameObjectWithTag("BC").GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("ruining");
    }
}



