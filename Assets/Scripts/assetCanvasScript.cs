using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;


public class assetCanvasScript : MonoBehaviour
{
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
        callFetchArt();
    }

    public void callFetchArt()
    {
        StartCoroutine(FetchArt());
    }


    IEnumerator FetchArt()
    {
        using (var uwr = new UnityWebRequest(assetURL, UnityWebRequest.kHttpVerbGET))
        {
            uwr.downloadHandler = new DownloadHandlerTexture();
            yield return uwr.SendWebRequest();
            content.texture = DownloadHandlerTexture.GetContent(uwr);
        }
    }

    // Update is called once per frame
    void Update()
    {
        content.transform.localScale = assetScale;
    }
}
