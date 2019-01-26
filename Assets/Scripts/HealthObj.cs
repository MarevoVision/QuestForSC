using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthObj : MonoBehaviour {

    public float health;
    private MeshRenderer meshRenderer;
    public GameObject particle, pcStar;
    public GameObject slider, score;
	// Use this for initialization
	void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = new Color32(123, 123, 123, 119);
        particle.SetActive(false);
        pcStar.SetActive(false);
        slider.SetActive(true);
        score.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if(health <= 0){
            meshRenderer.material.color = new Color32(0, 50, 160, 119);
            particle.SetActive(true);
            pcStar.SetActive(true);
            slider.SetActive(false);
            score.SetActive(true);
            particle.GetComponent<ParticleSystemRenderer>().enabled = true;
            pcStar.GetComponent<ParticleSystemRenderer>().enabled = true;
        }
        if (health <= 0)
        {
            health = 0;
        }
            slider.GetComponent<Slider>().value = health;
    }
}
