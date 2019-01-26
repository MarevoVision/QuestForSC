using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour {

    public Image btnImage;
    public Sprite onSound;
    public Sprite offSound;
    bool iswork;
    
	// Use this for initialization
	void Start () {
        iswork = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnOff()
    {
        if(iswork == true)
        {
            btnImage.sprite = offSound;
            FindObjectOfType<SoundManager>().VolumeOff("Stay");
            FindObjectOfType<SoundManager>().VolumeOff("Run");
            iswork = false;
        }
        else
        {
            btnImage.sprite = onSound;
            FindObjectOfType<SoundManager>().VolumeOn("Stay");
            FindObjectOfType<SoundManager>().VolumeOn("Run");
            iswork = true;
        }
        
    }

}
