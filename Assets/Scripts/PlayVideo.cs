using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour {

    public GameObject videoPlayer;
    public SpriteRenderer spriteRenderer;

    void OnMouseDown()
    {
            videoPlayer.SetActive(true);
            spriteRenderer.enabled = false;
        }

}
