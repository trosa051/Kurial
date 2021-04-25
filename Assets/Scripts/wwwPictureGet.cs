using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;


public class wwwPictureGet : MonoBehaviour {
	public string url = "";
    public InputField urlBox;
    public RawImage rawIMG;
    public Texture def;
	/*
	IEnumerator Start() {
		// Start a download of the given URL
		UnityWebRequestTexture www = new UnityWebRequest(url);

		// Wait for download to complete 
		yield return www;

		// assign texture
		rawIMG.texture = www.GetTexture;
	}*/
    // void OnEnable()
    // {
    //     //Debug.Log("PrintOnDisable: script was disabled");
    //     rawIMG.texture = def;
    // }
    
    IEnumerator pong()
    {
        url = urlBox.text;
        using (var uwr = new UnityWebRequest(url, UnityWebRequest.kHttpVerbGET))
        {
            uwr.downloadHandler = new DownloadHandlerTexture();
            yield return uwr.SendWebRequest();

            try
            {
                rawIMG.texture = DownloadHandlerTexture.GetContent(uwr);
            }
            catch (Exception e) 
            {
                Debug.Log("A kuration has a broken link!");
            }
        }
    }

    private void Awake() {
        rawIMG.texture = def;
    }

    public void ping() {
        StartCoroutine("pong");
        
    }

}