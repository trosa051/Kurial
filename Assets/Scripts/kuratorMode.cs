//REMAKE THIS SCRIPT

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kuratorMode : MonoBehaviour
{

    public GameObject myPrefab;
    GameObject clone;
    public GameObject spawnPoint;
    public RawImage textureToUse;
    public InputField urlBox;	
    //KurationID <- grab that from sel
    public Vector3 Size;
    public Vector3 Location;
    public Vector3 Rotation;
    public InputField AssetName;
    public InputField AssetDescription;
    public string url = "";
    int assetID = -1;
    public sel sr;


    void Start()
    {
        sr = (sel)FindObjectOfType<sel>();
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("art2DAnchor");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }


    public void noAnchor(){
        callAddAsset(false);
        // GameObject clone = Instantiate(myPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        // assetCanvasScript acs = clone.GetComponent<assetCanvasScript>();
        // acs.assetName = AssetName.text;
        // acs.assetDesc = AssetDescription.text;
        // acs.assetURL = urlBox.text;
        // //acs.
        // //Renderer rend = clone.GetComponent<Renderer> ();
        // //rend.material.mainTexture = textureToUse.texture;
        // Location = clone.transform.position;
        // Rotation = clone.transform.eulerAngles;
        // acs.callFetchArt();
        // callAddAsset();
        // acs.assetID = assetID;
        // //clone.GetComponent<Renderer>().material.mainTexture = textureToUse.texture as Texture;
    }

    public void yesAnchor(){
        callAddAsset(true);
        // Debug.Log(FindClosestEnemy());
        // GameObject clone = Instantiate(myPrefab, (FindClosestEnemy().transform.position+new Vector3(0,0,0)), FindClosestEnemy().transform.rotation);
        // assetCanvasScript acs = clone.GetComponent<assetCanvasScript>();
        // acs.assetName = AssetName.text;
        // acs.assetDesc = AssetDescription.text;
        // acs.assetURL = urlBox.text;
        // //acs.assetURL = urlBox.text;
        // //Renderer rend = clone.GetComponent<Renderer> ();
        // //rend.material.mainTexture = textureToUse.texture;
        // Location = clone.transform.position;
        // Rotation = clone.transform.eulerAngles;
        // acs.callFetchArt(); 
        // callAddAsset();
        // //acs.assetID = assetID;
    }


    public void callAddAsset(bool isAnchored){
        StartCoroutine(AddAsset(isAnchored));
    }

    IEnumerator AddAsset(bool isAnchored)
    {
        if (isAnchored)
        {
            Debug.Log(FindClosestEnemy()); //logs the anchor used
            clone = Instantiate(myPrefab, (FindClosestEnemy().transform.position+new Vector3(0,0,0)), FindClosestEnemy().transform.rotation);
        }
        else if (!isAnchored)
        {
            clone = Instantiate(myPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        //GameObject.Find("_manager").GetComponent<sel>().editing = false;
        assetCanvasScript acs = clone.GetComponent<assetCanvasScript>(); 
        acs.isNaturalSpawn = false;
        acs.assetName = AssetName.text;
        acs.assetDesc = AssetDescription.text;
        acs.assetURL = urlBox.text;
        Location = clone.transform.position;
        Rotation = clone.transform.eulerAngles;
        acs.callFetchArt(); //This gets the right art

        WWWForm form = new WWWForm();
        form.AddField("KurationID",sr.kurID.ToString());
        form.AddField("AssetURL",urlBox.text);
        form.AddField("SizeX","1");
        form.AddField("SizeY","1");
        form.AddField("SizeZ","1");
        form.AddField("LocationX",Location.x.ToString());
        form.AddField("LocationY",Location.y.ToString());
        form.AddField("LocationZ",Location.z.ToString());
        form.AddField("RotationX",Rotation.x.ToString());
        form.AddField("RotationY",Rotation.y.ToString());
        form.AddField("RotationZ",Rotation.z.ToString());
        form.AddField("AssetName",AssetName.text);
        form.AddField("AssetDescription",AssetDescription.text);

        var sub = new WWW("https://kurial.space/php/logAsset.php",form);
        yield return sub;

        if(sub.text[0] != '0')
        {
            Debug.Log("Error: "+sub.text);
        }
        else
        {
            Debug.Log("Asset added to the db succesfully");
        }
        //The problem here is that I need to have the assetID so I can edit the correct asset.
        //To correct this im going to attempt to add a second WWW in this IEnumerator
        WWWForm form2 = new WWWForm();
        form2.AddField("KurationID",sr.kurID.ToString());
        var wub = new WWW("https://kurial.space/php/getLatestAsset.php",form2);
        yield return wub;
        //at this point 
        Debug.Log("Asset # " + wub.text.Split('\t')[1] + " uploaded.");
        acs.assetID = int.Parse(wub.text.Split('\t')[1]);
        acs.isNaturalSpawn = true;
    }

}


///////////////////////////////////////////////////
// Find the name of the closest enemy
// https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
