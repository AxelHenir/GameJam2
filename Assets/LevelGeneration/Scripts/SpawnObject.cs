using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] objects;

    private void Start()
    {
        int rand = Random.Range(0, objects.Length);
        GameObject instance = (GameObject)Instantiate(objects[rand],transform.position,Quaternion.identity); //making hte tile instances children instead of full on parent
        instance.transform.parent = transform; //child first and then the parent 
    }
}
