using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;


public class wwwPictureGet : MonoBehaviour {
	public string url = "https://placedog.net/200/150?random";
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
            rawIMG.texture = DownloadHandlerTexture.GetContent(uwr);
        }
    }

    private void Update() {
        
    }

    public void ping() {
        StartCoroutine("pong");
        
    }

}