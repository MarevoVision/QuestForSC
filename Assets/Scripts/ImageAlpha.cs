using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAlpha : MonoBehaviour {

    public Image faC;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AlphaOn()
    {
        faC.color = new Color32(255, 255, 255, 255);
    }

    public void AlphaOff()
    {
        faC.color = new Color32(255, 255, 255, 0);
    }
}
