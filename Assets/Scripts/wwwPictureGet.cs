using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;


public class wwwPictureGet : MonoBehaviour {
	public string url = "";
    public InputField urlBox;
    public RawImage rawIMG;
	/*
	IEnumerator Start() {
		// Start a download of the given URL
		UnityWebRequestTexture www = new UnityWebRequest(url);

		// Wait for download to complete 
		yield return www;

		// assign texture
		rawIMG.texture = www.GetTexture;
	}*/
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

    private void Update() {
        
    }

    public void ping() {
        StartCoroutine("pong");
        
    }

}