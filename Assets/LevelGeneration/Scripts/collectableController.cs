using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class collectableController : MonoBehaviour
{   
    private UnityEngine.Rendering.Universal.Light2D light2DComponent;
    public SpriteRenderer spriteRenderer;
    public bool collected = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        light2DComponent = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player" && collected == false){
            Collect();
        }
    }

    void Collect(){
        spriteRenderer.enabled = false;
        collected = true;
        light2DComponent.intensity = 0f;

        // Sound
        AudioSource source = GetComponent<AudioSource>();
        source.Play();

        // What am I?
        string collectableType = this.tag;

        // Tell gamehandler
        GameObject gameHandlerObject = GameObject.Find("GameHandler");
        Gamehandler gameHandler = gameHandlerObject.GetComponent<Gamehandler>();
        gameHandler.collect(collectableType);
    }
}
