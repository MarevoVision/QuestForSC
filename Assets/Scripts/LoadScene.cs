using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public string sceneName;
	// Use this for initialization
	void Start () {
        StartCoroutine(LoadLevel());
	}
	


	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator LoadLevel(){
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(sceneName);
    }
}
