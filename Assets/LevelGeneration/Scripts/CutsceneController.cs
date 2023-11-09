using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutsceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer;


    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    public void PlayVideo()
    {
        videoPlayer.Play();
    }

    void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene("MainGame");
    }





    
}
