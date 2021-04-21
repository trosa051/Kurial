using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class accountLanding : MonoBehaviour
{

    public InputField kurationNameField;
    //public Dropdown templateField;
    public Dropdown roomType;
    public Toggle visToggle;
    public sel choice;
    public Button createButton;

    public Text playerDisplay;
    public Text lastDisplay;
    public Text AccDisplay;
    //public Text scoreDisplay;
    
    
    private void Awake(){
        callPopulateFields();
    }

        public void callPopulateFields()
    {
        StartCoroutine(PopulateFields());
    }


    IEnumerator PopulateFields()
    {
        if (DBManager.email == null ){
            SceneManager.LoadScene(0);
        }
        if(playerDisplay != null) playerDisplay.text = "Welcome " + DBManager.username;
        if(DBManager.LastLog[0] != '0'){
            if(lastDisplay != null) lastDisplay.text = "Your last login was: " + DBManager.LastLog;
        }
        else if(DBManager.LastLog[0] == '0'){
            if(lastDisplay != null) lastDisplay.text = "This is your first time logging in. Your previous login will be displayed here on your next visit.";// + DBManager.LastLog;
        }
        if (DBManager.AccStanding == 'G'){
        if(AccDisplay != null) AccDisplay.text = "Your account is in GOOD standing.";
        }
        else if (DBManager.AccStanding == 'B'){
        if(AccDisplay != null) AccDisplay.text = "You're BANNED. Email banappeals@kurial.space to appeal this decision.";
        }
        yield return 0;
    }



    public void logoutAndBringBack()
    {
        GameObject.Destroy(GameObject.Find("_manager"));
        DBManager.Logout();
        SceneManager.LoadScene(0);
    }

    public void callCreateKuration()
    {
        StartCoroutine(CreateKuration());
    }


    IEnumerator CreateKuration()
    {
        WWWForm form = new WWWForm();
        Debug.Log("Attempting to kurate " + kurationNameField.text);
        Debug.Log("Kurated by: " + DBManager.username);
        Debug.Log("Room Type: " + roomType.value);
        Debug.Log("Visibility: " + visToggle.isOn);
        form.AddField("kurationName",kurationNameField.text);
        form.AddField("kuratorName",DBManager.username);
        form.AddField("template",roomType.value);
        if (visToggle.isOn == true)
        {
            form.AddField("shareStatus","v");
        }
        else
        {
            form.AddField("shareStatus","h");
        }

        var sub = new WWW("https://kurial.space/php/makeKuration.php",form);
        yield return sub;
        Debug.Log("PHP said: " + sub.text);
        if(sub.text[0] == '0')
        {   
            choice = GameObject.Find("_manager").GetComponent<sel>();
            choice.editing = true;
            string[] phpReturnExplode = sub.text.Split('\t');
            choice.kurID = Int32.Parse(phpReturnExplode[1]);
            SceneManager.LoadScene(2);
        }
        else
        {
            Debug.Log("Kuration creation failed. Error #" + sub.text);
        }

    }

    public void VerifyInputs()
    {
        createButton.interactable = (kurationNameField.text.Length > 1);
    }

}
