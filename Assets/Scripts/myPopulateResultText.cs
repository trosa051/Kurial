using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPopulateResultText : MonoBehaviour
{

    //public roomResultText rrt;
    public myKurations bk;
    public GameObject[] results;
    
    // Start is called before the first frame update
    void Start()
    {
        //rrt = rrt.GetComponent<roomResultText>();
        bk = bk.GetComponent<myKurations>();
    }

    // Update is called once per frame
    public void OnClick()
    {
        results = GameObject.FindGameObjectsWithTag("result");
        Array.Resize(ref results,bk.roomsAmt);
        for (int i = 0; i < bk.roomsAmt; i++){
            var ts = results[i].GetComponent<roomResultText>();
            ts.kurID = bk.kuRoom[i].roomID;
            ts.roomName.text = bk.kuRoom[i].roomName;
            ts.kurator.text = bk.kuRoom[i].kurator;
            ts.roomType.text = bk.kuRoom[i].roomType;
            ts.creationDate.text = bk.kuRoom[i].creationDate;
            if(bk.kuRoom[i].lastUpdate == "0000-00-00 00:00:00"){
               ts.LastUpdated.text = "Never"; 
            }
            else{   
            ts.LastUpdated.text = bk.kuRoom[i].lastUpdate;
            }
        }
    }
}
