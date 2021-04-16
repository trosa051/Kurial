using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Asset
{
    public int assetID;
    public string assetURL;
    public string assetName;
    public string assetDesc;
    public Vector3 assetScale;
    public Vector3 assetPosition;
    public Vector3 assetRotation;
    public Asset(int ID, string name, string desc, string URL, Vector3 scale,  Vector3 pos,  Vector3 rot){
        assetName = name;
        assetDesc = desc;
        assetID = ID;
        assetURL = URL;
        assetScale = scale;
        assetPosition = pos;
        assetRotation = rot;
    }
}

    /*
	0   EntryNumber
    1	KurationID
    2   AssetName
    3   AssetDescription
	4	AssetID
	5	AssetURL
	6	SizeX
	7	SizeY
	8	SizeZ
	9	LocationX
	10	LocationY
	11	LocationZ
	12	RotationX
	13	RotationY
	14	RotationZ
    */

public class populateKuration : MonoBehaviour
{

    public GameObject kanvas;
    public List<Asset> ass = new List<Asset>();
    [SerializeField]
    int kurationCount = 0;

    // Start is called before the first frame update
    void Awake()
    {
      callPopulateRoom();
      //spawnArt();  
    }

    // Update is called once per frame
    public void callPopulateRoom()
    {
        StartCoroutine(PopulateRoom());
    }

    IEnumerator PopulateRoom()
    {
        WWWForm form = new WWWForm();
        sel choice = GameObject.Find("_manager").GetComponent<sel>();
        form.AddField("kurationID",choice.kurID);
        var sub = new WWW("https://kurial.space/php/enterKuration.php",form);
        yield return sub;
        if(sub.text[0] != '0')
        {
            Debug.Log(sub.text);
        }
        else
        {
            
        Debug.Log(sub.text);
        
        //Array.Resize(ref ass,artAmt);
        string[] assets = sub.text.Split('\n');

        string[] inf = assets[0].Split('\t');
        //Debug.Log(inf[1]);

        bool isParsable = Int32.TryParse(inf[1], out kurationCount);
        if (!isParsable)
        Console.WriteLine("Could not be parsed. Get ready for hell.");    
        //if(assets.Length > 0){
        
        for(int i = 1 , j = 0; i <= (kurationCount); i++, j++){
            string[] assExplode = assets[i].Split('\t');
            ass.Add(new Asset() {assetName =assExplode[2] , assetDesc = assExplode[3], assetID = Int32.Parse(assExplode[4]) , assetURL = assExplode[5], assetScale = new Vector3( float.Parse(assExplode[6]), float.Parse(assExplode[7]), float.Parse(assExplode[8])),assetPosition = new Vector3( float.Parse(assExplode[9]), float.Parse(assExplode[10]), float.Parse(assExplode[11])),assetRotation = new Vector3( float.Parse(assExplode[12]), float.Parse(assExplode[13]), float.Parse(assExplode[14]))});    
        }
        spawnArt();
        }
    }

    public void spawnArt()
    {
        for (int i = 0; i < kurationCount; i++) 
        {
            Debug.Log("Attempting to create asset #"+i);
            try{
            assetCanvasScript acs = kanvas.GetComponent<assetCanvasScript>();
            acs.assetName = ass[i].assetName;
            acs.assetDesc = ass[i].assetDesc;
            acs.assetID = ass[i].assetID;
            acs.assetURL = ass[i].assetURL;
            acs.assetScale = ass[i].assetScale;
            kanvas.SetActive(true); 
            Instantiate(kanvas, ass[i].assetPosition, Quaternion.Euler(ass[i].assetRotation));
            //acs.callFetchArt();  
            }
            catch (Exception e) 
            {
                Debug.Log("Could not create Kuration #"+i);
            }
        }
    }
}
