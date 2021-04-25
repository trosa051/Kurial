using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine;

public class editArtScript : MonoBehaviour
{
    public assetCanvasScript gob;

    public wwwPictureGet clickonce;
    public Canvas pauseCanvas;

    public InputField assetName;
    public InputField assetDesc;
    public InputField assetURL;
    
    public InputField assetXScale;
    public InputField assetYScale;
    public Slider sillyXSlider;
    public Slider sillyYSlider;
    
    public string assetNamestr = "";
    public string assetDescstr = "";
    public string assetURLstr = "";

    //[SerializeField]
    public int assetID = -1;
    
    public float assetXScalef = 1;
    public float assetYScalef = 1;

    //public InputField urlBox;
    public RawImage rawIMG;


    // Update is called once per frame
    
    public void OnChange(){
        //assetID = 
        assetNamestr = assetName.text;
        assetDescstr = assetDesc.text;
        assetURLstr = assetURL.text;
        //assetXScale.text = assetXScalef.ToString();
        //assetYScale.text = assetYScalef.ToString();
        sillyXSlider.value =assetXScalef;
        sillyYSlider.value =assetYScalef;
    //gob.transform.GetChild(0).transform.localScale = new Vector3(sillyXSlider.value,sillyYSlider.value,1f);
    }

    public void OnChangeLite(){
        //assetID = 
        assetNamestr = assetName.text;
        assetDescstr = assetDesc.text;
        assetURLstr = assetURL.text;
        //assetXScale.text = assetXScalef.ToString();
        //assetYScale.text = assetYScalef.ToString();
        //sillyXSlider.value =assetXScalef;
        //sillyYSlider.value =assetYScalef;
    //gob.transform.GetChild(0).transform.localScale = new Vector3(sillyXSlider.value,sillyYSlider.value,1f);
    }

    public void OnBack(){
        //we know the assetID so we can search populateKuration's "ass" List and get the assetScale from the struct that has the same assetID
        //Vector3 original = NewList.Find(x => x.F1 == "AAA");
        gob.assetScale = GameObject.Find("roomSet").GetComponent<populateKuration>().ass.Single(Asset => Asset.assetID == assetID).assetScale;
    }

    public void OnEdit(){
        //we know the assetID so we can search populateKuration's "ass" List and get the assetScale from the struct that has the same assetID
        //Vector3 original = NewList.Find(x => x.F1 == "AAA");
        Vector3 assScal = GameObject.Find("roomSet").GetComponent<populateKuration>().ass.Single(Asset => Asset.assetID == assetID).assetScale;
        assScal = gob.assetScale;
        callUploadUpdate();

    }
    
    void Start(){
        OnChange();
    }


    void OnEnable()
    {
        /*
        assetName.text = assetNamestr;
        assetDesc.text = assetDescstr;
        assetURL.text = assetURLstr;
        */
        pauseCanvas.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //callRetrieveAss();
        //clickonce.ping();
    }

    /*public void assName(UnityEngine.UI.Text val){
        assetNamestr = float.Parse(val.text);
    }
    public void assDesc(UnityEngine.UI.Text val){
        assetDescstr = float.Parse(val.text);
    }
    public void assURL(UnityEngine.UI.Text val){
        assetURLstr = float.Parse(val.text);
    }*/

    public void callRetrieveAss() {
        StartCoroutine(RetrieveAss());
    }

    public void callUploadUpdate() {
        StartCoroutine(UploadUpdate());
    }


        
    public void xSliderControl(System.Single val){
        //inInput.text = string.Format("{0:G}", val);
        gob.assetScale.x = val;
    }  
    public void ySliderControl(System.Single val){
        //inInput.text = string.Format("{0:G}", val);
        gob.assetScale.y = val;
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
    
    IEnumerator UploadUpdate()
    {
        WWWForm form = new WWWForm();
        Debug.Log("Attempting to update asset with ID " + assetID);
        form.AddField("AssetID",assetID);
        Debug.Log("AssetURL = " + assetURLstr);
        form.AddField("AssetURL",assetURLstr);
        Debug.Log("Size = " + gob.assetScale);
        form.AddField("SizeX",gob.assetScale.x.ToString());
        form.AddField("SizeY",gob.assetScale.y.ToString());
        form.AddField("SizeZ",gob.assetScale.z.ToString());
        Debug.Log("AssetName = " + assetNamestr);
        form.AddField("AssetName",assetNamestr);
        Debug.Log("AssetDescription = " + assetDescstr);
        form.AddField("AssetDescription",assetDescstr);
        //form.AddField("assetToDel",ass);
        var sub = new WWW("https://kurial.space/php/updateAsset.php",form);
        yield return sub;
        Debug.Log(sub.text);
        if(sub.text[0] == '0')
        {
            Debug.Log("Update asset successful.");
        }
        else
        {
            Debug.Log("Update asset unsuccessful.");
        }
    }

}