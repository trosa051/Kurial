using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;


public class assetCanvasScript : MonoBehaviour
{
    public Canvas cnvs;
    public EditOrViewKuration eovk;
    public string assetName = "";
    public string assetDesc = "";
    public int assetID = -1;
    public string assetURL = "";
    public Vector3 assetScale = new Vector3(1,1,1);
    public RawImage content;

    // Start is called before the first frame update
    void Awake()
    {
        //set the canvas event camera to the only camera in the scene
        eovk = GameObject.FindWithTag("Player").GetComponent<EditOrViewKuration>();
        cnvs.worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        callFetchArt();
    }

    public void OnClick()
    {
        editArtScript eas = GameObject.FindWithTag("edit").GetComponent<editArtScript>();
        eas.assetName.text = assetName;
        eas.assetDesc.text = assetDesc;
        eas.assetURL.text = assetURL;
        eas.OnChange();
        eas.callRetrieveAss();
        viewArtScript vas = GameObject.FindWithTag("view").GetComponent<viewArtScript>();
        vas.assetName.text = assetName;
        vas.assetDesc.text = assetDesc;
        vas.assetURL = assetURL;
        vas.callRetrieveAss();
        eovk.OnClick();
    }

    public void callFetchArt()
    {
        StartCoroutine(FetchArt());
    }


    IEnumerator FetchArt()
    {
        Debug.Log(assetURL);
        using (var uwr = new UnityWebRequest(assetURL, UnityWebRequest.kHttpVerbGET))
        {
            uwr.downloadHandler = new DownloadHandlerTexture();
            yield return uwr.SendWebRequest();
            try
            {
            content.texture = DownloadHandlerTexture.GetContent(uwr);
            }
            catch (Exception e) 
            {
            Debug.Log("Failed to Upload: "+assetURL);
            //Debug.Log("A kuration has a broken link!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        content.transform.localScale = assetScale;
    }
}
