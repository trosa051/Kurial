using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine;

public class editArtScript : MonoBehaviour
{
    public wwwPictureGet clickonce;
    public Canvas pauseCanvas;

    public InputField assetName;
    public InputField assetDesc;
    public InputField assetURL;
    
    public string assetNamestr = "";
    public string assetDescstr = "";
    public string assetURLstr = "";
    
    //public InputField urlBox;
    public RawImage rawIMG;


    // Update is called once per frame
    void OnEnable()
    {
        assetName.text = "beans";
        assetDesc.text = "beans";
        assetURL.text = "beans";
        assetName.text = assetNamestr;
        assetDesc.text = assetDescstr;
        assetURL.text = assetURLstr;
        pauseCanvas.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //callRetrieveAss();
        //clickonce.ping();
    }


    public void callRetrieveAss() {
        StartCoroutine(RetrieveAss());
    }

    IEnumerator RetrieveAss()
    {
        using (var uwr = new UnityWebRequest(assetURL.text, UnityWebRequest.kHttpVerbGET))
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