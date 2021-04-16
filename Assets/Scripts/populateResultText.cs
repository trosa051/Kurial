using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class populateResultText : MonoBehaviour
{

    //public roomResultText rrt;
    public BrowseKurations bk;
    public GameObject[] results;
    
    // Start is called before the first frame update
    void Start()
    {
        //rrt = rrt.GetComponent<roomResultText>();
        bk = bk.GetComponent<BrowseKurations>();
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
            /*switch (bk.kuRoom[i].roomType)
            {
                case "0":
                ts.roomType.text = "TJ's Room";
                break;
                case "1":
                ts.roomType.text = "Colton's Room";
                break;
                case "2":
                ts.roomType.text = "Tony's Room";
                break;
                case "3":
                ts.roomType.text = "Reed's Room";
                break;
                case "4":
                ts.roomType.text = "Texas";
                break;
                case "5":
                ts.roomType.text = "Original Room";
                break;
                default:
                ts.roomType.text = "Unknown";
                break;
            }*/
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
