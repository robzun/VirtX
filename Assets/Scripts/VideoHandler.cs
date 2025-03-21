using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class VideoHandler : MonoBehaviour
{
   private VideoPlayer player;
   public Button button;
   public Sprite startSprite;
   public Sprite stopSprite;
   public GameObject interactionHud;
   public GameObject pauseButton; // Same as var button, but as a GameObject can't access the sprite and as Button can't toggle SetActive()
       
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.loopPointReached += VideoEnded;
    }
    
    // Play/Pause
    public void PausePlayVideo()
    {
        if (player.isPlaying == false)
        {
            player.Play();
            button.image.sprite = stopSprite;
        }
        else
        {
            player.Pause();
            button.image.sprite = startSprite;
        }
    }
    
    // Terminar video
    void VideoEnded(VideoPlayer vp)
    {
        Debug.Log("Video Ended");
        interactionHud.SetActive(true);
        pauseButton.SetActive(false);
    }
}
