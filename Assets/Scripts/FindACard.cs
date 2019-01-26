using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;
using UnityEngine.UI;


public class FindACard : MonoBehaviour
{
    public GameObject findACard;
    public GameObject video;
    public Button shoot;

    public void OnFindACard()
    {
        findACard.SetActive(true);
        shoot.interactable = false;
        video.GetComponent<VideoPlayer>().enabled = false;
    }

    public void OffFindACard()
    {
        findACard.SetActive(false);
        shoot.interactable = true;
        video.GetComponent<VideoPlayer>().enabled = true;
    }
}
