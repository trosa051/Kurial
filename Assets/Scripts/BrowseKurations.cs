using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Kuration
{
    public string roomName;
    public string kurator;
    public string roomType;
    public string creationDate;
    public string lastUpdate;
    public Kuration(string name, string krtr, string room, string creation, string lastChanged){
        roomName = name;
        kurator = krtr;
        roomType = room;
        creationDate = creation;
        lastUpdate = lastChanged;
    }
}

public class BrowseKurations : MonoBehaviour
{
    public Kuration[] kuRoom;
    public InputField kurationSearchField;
    public int roomsAmt = 0;
    public instantiateResults iR;
    public populateResultText prt;
    //public Dropdown templateField;
    //public Dropdown roomType;
    //public Toggle visToggle;

    //public Button createButton;

    //public Text playerDisplay;
    //public Text lastDisplay;
    //public Text AccDisplay;
    //public Text scoreDisplay;
    
    
    private void Start(){
        iR = iR.GetComponent<instantiateResults>();
        callBrowseKuration();
        iR.OnClick();
    }

    public void callBrowseKuration()
    {
        StartCoroutine(BrowseKuration());
    }


    IEnumerator BrowseKuration()
    {
        WWWForm form = new WWWForm();
        Debug.Log("Attempting to search " + kurationSearchField.text);;
        form.AddField("keyWord",kurationSearchField.text);
        //form.AddField("kuratorName",DBManager.username);
        //form.AddField("template",roomType.value);
        // if (visToggle.isOn == true)
        // {
        //     form.AddField("shareStatus","v");
        // }
        // else
        // {
        //     form.AddField("shareStatus","h");
        // }

        var sub = new WWW("https://kurial.space/php/browseKuration.php",form);
        yield return sub;
        if(sub.text[0] == '0')
        {
            //Debug.Log(sub.text);
        }
        else
        {
            Debug.Log("Kuration browse failed. Error #" + sub.text);
            //exit(0);
        }


        string[] rooms = sub.text.Split('\n');
        for(int i = 0; i < rooms.Length-1; i++){
        Debug.Log(rooms[i]);
        }

        string[] inf = rooms[0].Split('\t');
        //Debug.Log(inf[1]);

        bool isParsable = Int32.TryParse(inf[1], out roomsAmt);

        if (!isParsable)
        Console.WriteLine("Could not be parsed. Get ready for hell.");      

        Array.Resize(ref kuRoom,roomsAmt); //(sub.text[3].GetNumericValue()));


        List<int> myList = new List<int>();
        for(int i = 1 , j = 0; i <= (roomsAmt); i++, j++){
            string[] roomsExplode = rooms[i].Split('\t');
            if(roomsExplode.Length > 0){
                kuRoom[j].roomName = roomsExplode[1];
                kuRoom[j].kurator = roomsExplode[2];
                kuRoom[j].roomType = roomsExplode[3];
                kuRoom[j].creationDate = roomsExplode[4];
                kuRoom[j].lastUpdate = roomsExplode[5];
            }
        }

    iR.OnClick();
    prt.OnClick();


        
    }

}
