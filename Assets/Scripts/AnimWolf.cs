using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimWolf : MonoBehaviour
{

    private Animation animRun;
    public float seconds;

    private bool runW;
    private Transform woolf;
    

    // Use this for initialization
    void Start () {
        woolf = GetComponent<Transform>();
        animRun = GetComponent<Animation>();
        FindObjectOfType<SoundManager>().Play("Stay");
        runW = false;
    }
	
    // Update is called once per frame
    void Update () {
    }

    private void OnMouseDown()
    {
        if(runW == false)
        {
            AllStop();
            runW = true;
            StartCoroutine("WolfRun");
        }
    }

    public void AllStop()
    {
        FindObjectOfType<SoundManager>().Stop("Stay");
        FindObjectOfType<SoundManager>().Stop("Run");
        animRun.Play("Wolf_Skeleton|000");
        StopCoroutine("WolfRun");
    }
    IEnumerator WolfRun()
    {
        animRun.Play("Wolf_Skeleton|Wolf_Run_Cycle_");
        FindObjectOfType<SoundManager>().Play("Run");
        yield return new WaitForSeconds(seconds);
        FindObjectOfType<SoundManager>().Stop("Run");
        animRun.Play("Wolf_Skeleton|000");
        FindObjectOfType<SoundManager>().Play("Stay");
        runW = false;
        yield break;
    }

    public void runWolff()
    {
        runW = false;
    }

    public void playStay()
    {
        FindObjectOfType<SoundManager>().Play("Stay");
    }

    public void StopFocus()
    {
        if(runW == true)
        {
            FindObjectOfType<SoundManager>().Stop("Run");
            animRun.Play("Wolf_Skeleton|000");
            StopCoroutine("WolfRun");
            FindObjectOfType<SoundManager>().Play("Stay");
            runW = false;
        }
        else
        {
           // animRun.Play("Wolf_Skeleton|000");
            StopCoroutine("WolfRun");
        }
        
        if(FindObjectOfType<ScreenshotPreview>().shotMenu.activeSelf == true)
        {
            FindObjectOfType<SoundManager>().VolumeOff("Stay");
            FindObjectOfType<SoundManager>().VolumeOff("Run");
        }
        else
        {
            FindObjectOfType<SoundManager>().VolumeOn("Stay");
            FindObjectOfType<SoundManager>().VolumeOn("Run");
        }
        
    }

    public void RotateToCameraFace()
    {
        Vector3 targetPostition = new Vector3(Camera.main.transform.position.x, woolf.position.y, Camera.main.transform.position.z);
        woolf.LookAt(targetPostition);

    }
    
}
