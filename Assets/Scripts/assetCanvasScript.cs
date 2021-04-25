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
    public bool isNaturalSpawn = true;
    

    // Start is called before the first frame update
    void Start()
    {
        /*assetName = "";
        assetDesc = "";
        isNaturalSpawn = true;
        assetURL = "";
        assetID = -1;*/
        //callFetchArt();
    }

    void Awake()
    {
        //set the canvas event camera to the only camera in the scene
        eovk = GameObject.FindWithTag("Player").GetComponent<EditOrViewKuration>();
        cnvs.worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        //sel choice = GameObject.Find("_manager").GetComponent<sel>();
        if (isNaturalSpawn == true) callFetchArt();
        //if viewing kurations we need this to happen to actually load them. Otherwise dont do it bc its taken care of in kuratorMode.
        //The way whtat I checked that was with the sel script pretty sure

    }

    public void OnClick()
    {
        deleteAsset del = GameObject.Find("EditArtCanvas").GetComponent<deleteAsset>();
        del.poof = this.gameObject;
        del.ass = assetID;

        //scaleUpdate

        editArtScript eas = GameObject.FindWithTag("edit").GetComponent<editArtScript>();
        eas.gob = this;
        eas.assetName.text = assetName;
        eas.assetDesc.text = assetDesc;
        eas.assetURL.text = assetURL;
        eas.assetXScalef = this.gameObject.transform.GetChild(0).transform.localScale.x;
        eas.assetYScalef = this.gameObject.transform.GetChild(0).transform.localScale.y;
        eas.assetID = assetID;
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


    
    public void xSliderControl(System.Single val){
        //inInput.text = string.Format("{0:G}", val);
        assetScale.x = val;
    }

    // public void xInputControl(UnityEngine.UI.Text val){
    //     //inSlide.value = float.Parse(val.text);
    //     assetScale.x = float.Parse(val).ToString();
    // }

    public void ySliderControl(System.Single val){
        //inInput.text = string.Format("{0:G}", val);
        assetScale.y = val;
    }

    // public void yInputControl(UnityEngine.UI.Text val){
    //     //inSlide.value = float.Parse(val.text);
    //     assetScale.y = float.Parse(val);
    // }


    // Update is called once per frame
    void Update()
    {
        content.transform.localScale = assetScale;

        //this.gameObject.transform.GetChild(0).transform.localScale.x;
    }
}
