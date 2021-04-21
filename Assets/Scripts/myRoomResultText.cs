using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class myRoomResultText : MonoBehaviour
{
    public int kurID;
    public String roomDesc;
    public Text roomName;
    public Text kurator;
    public Text roomType;
    public Text creationDate;
    public Text LastUpdated;
    public GameObject resultBod;
    public sel sr;
    [SerializeField]
    bool bodied = false;
    GameObject bod;
    string rm = "0";
    // Start is called before the first frame update
    void Start()
    {
        rm = roomType.text;
        sr = (sel)FindObjectOfType<sel>();
        switch (roomType.text)
        {
            case "0":
            roomType.text = "TJ's Room";
            break;
            case "1":
            roomType.text = "Colton's Room";
            break;
            case "2":
            roomType.text = "Tony's Room";
            break;
            case "3":
            roomType.text = "Reed's Room";
            break;
            case "4":
            roomType.text = "Texas";
            break;
            case "5":
            roomType.text = "Original Room";
            break;
            default:
            roomType.text = "Unknown";
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick(){
        GameObject[] bodTagged = GameObject.FindGameObjectsWithTag("bod");
        foreach(GameObject zes in bodTagged){
        zes.tag = "Untagged";
        GameObject.Destroy(zes);
        }
        
        if(!bodied){
        bod = Instantiate(resultBod);
        /*visibleIfKurator vif = bod.GetComponent<visibleIfKurator>();
        vif.resultKurator = kurator.text;
        vif.CheckName();*/
        bod.SetActive(true);
        bod.transform.SetParent(this.transform);
        bod.transform.SetParent(this.transform.parent);
        bod.transform.SetSiblingIndex(this.transform.GetSiblingIndex()+1);
        bod.transform.localScale = new Vector3(1,1,1);
        //bod.resultBody = 0;
        sr.setRoom = (sel.Name)(Int32.Parse(rm));
        sr.kurID = kurID;
        bodied = true;  
        }
        else if(bodied){
            //bod.isActiveAndEnabled(!bod.activeSelf);
            if (bod != null){
                bod.tag = "Untagged";
                GameObject.Destroy(bod);
            }
            bodied = false; 
            
        }
    //this.transform.DetachChildren();
    }

}
