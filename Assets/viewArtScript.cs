using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;

public class viewArtScript : MonoBehaviour
{
    public Text assetName;
    public Text assetDesc;
    public Canvas pauseCanvas;
    public string assetURL = "";
    //public InputField urlBox;
    public RawImage rawIMG;

    int assetID = -1;

    // Update is called once per frame
    void Start()
    {
        assetURL = "";
    }

    // Update is called once per frame
    void OnEnable()
    {
        pauseCanvas.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        callRetrieveAss();
    }


    public void callRetrieveAss() {
        StartCoroutine(RetrieveAss());
    }

    IEnumerator RetrieveAss()
    {
        using (var uwr = new UnityWebRequest(assetURL, UnityWebRequest.kHttpVerbGET))
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

}
