using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Kuration[] k;
    public InputField kurationSearchField;
    //public Dropdown templateField;
    //public Dropdown roomType;
    //public Toggle visToggle;

    //public Button createButton;

    //public Text playerDisplay;
    //public Text lastDisplay;
    //public Text AccDisplay;
    //public Text scoreDisplay;
    
    
    private void Awake(){
        //callBrowseKuration();
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
            Debug.Log(sub.text);
        }
        else
        {
            Debug.Log("Kuration browse failed. Error #" + sub.text);
        }
        
    }

}
