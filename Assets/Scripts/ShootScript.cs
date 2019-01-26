using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour {

    public Transform targetEng;
    private LineRenderer lineRenderer;
    private bool work;
    public HealthObj health;
    public float strongDamage;
    public Button btn;
    public SoundManager soundManager;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        work = false;
        lineRenderer.enabled = false;
    }
    public void ImagePointerDown()
    {
        if(health.health > 0 && btn.interactable == true)
        {
            work = true;
            lineRenderer.enabled = true;
            soundManager.Play("Electric");
        }
    }

    public void ImagePointerUp()
    {
        work = false;
        lineRenderer.enabled = false;
        soundManager.Stop("Electric");
    }

    void Update()
    {
        if(work == true){
            lineRenderer.SetPosition(0, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 1f, Camera.main.transform.position.z - 1f));
            lineRenderer.SetPosition(1, targetEng.position);
            health.health -= strongDamage;
        }
        if(health.health <= 0){
            work = false;
            lineRenderer.enabled = false;
            soundManager.Stop("Electric");
        }
    }
}