using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScreenshotPreview : MonoBehaviour {
	
	[SerializeField]
	GameObject canvas;

    [SerializeField]
    GameObject blink;

    public GameObject loadingScreen;
    public GameObject btnMenu, inMenu, shot, shotMenu;

    string toSave;
    public string ShareMessage;
    public string ShareSubject;
    bool iswork;
    public Image faC;
    public FindACard fAC;

    // Use this for initialization
    void Start () {
        iswork = false;
    }

    private void Update()
    {
        if (iswork == true)
        {
            StartCoroutine(ShareScreenshot());
            iswork = false;
        }
        
    }
    public void TakeAShot()
    {
        PanelClose();
        StartCoroutine("CaptureIt");
    }

    IEnumerator CaptureIt()
    {
        yield return new WaitForSeconds(0.5f);
        // prepare texture with Screen and save it
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0);
        texture.LoadRawTextureData(texture.GetRawTextureData());
        texture.Apply();
        
        // save to persistentDataPath File
        byte[] data = texture.EncodeToPNG();
        string destination = Path.Combine(Application.persistentDataPath,
                                          System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");
        File.WriteAllBytes(destination, data);

        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));
        canvas.GetComponent<Image>().sprite = sp;

        toSave = destination;

        NativeGallery.SaveImageToGallery(texture, "testAR_Trofymchuk", "Screenshot testAR_Trofymchuk {0}.png");
        Instantiate(blink, new Vector2(0f, 0f), Quaternion.identity);
        shotMenu.SetActive(true);
    }


    public void PanelClose()
    {
        btnMenu.SetActive(false);
        inMenu.SetActive(false);
        shot.SetActive(false);
        loadingScreen.SetActive(false);
        faC.color = new Color32(255, 255, 255, 0);
    }

    public void PanelOpen()
    {
        btnMenu.SetActive(true);
        shot.SetActive(true);
        shotMenu.SetActive(false);
        loadingScreen.SetActive(false);
        faC.color = new Color32(255, 255, 255, 255);

    }
    
    public void Share()
    {
        iswork = true;
    }

    private IEnumerator ShareScreenshot()
    {
        loadingScreen.SetActive(true);
        
        new NativeShare().AddFile(toSave).SetSubject(ShareSubject).SetText(ShareMessage).Share();

        yield return new WaitForSeconds(1f);
        loadingScreen.SetActive(false);
    }

}
