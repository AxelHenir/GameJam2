using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableController : MonoBehaviour
{   

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player"){
            collected();
        }
    }

    void collected(){
        spriteRenderer.enabled = false;
    }
}
