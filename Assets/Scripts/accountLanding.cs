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

    public Button createButton;

    public Text playerDisplay;
    public Text lastDisplay;
    public Text AccDisplay;
    //public Text scoreDisplay;
    
    
    private void Awake(){
        if (DBManager.username == null ){
            SceneManager.LoadScene(0);
        }
        playerDisplay.text = "Welcome " + DBManager.ID;
        lastDisplay.text = "Your last login was: " + DBManager.LastLog;
        if (DBManager.AccStanding == 'G'){
            AccDisplay.text = "Your account is in GOOD standing.";
        }
        else if (DBManager.AccStanding == 'B'){
            AccDisplay.text = "You're BANNED. banappeals@kurial.space to appeal this decision.";
        }
    }
    public void logoutAndBringBack()
    {
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
        Debug.Log("Room Type: " + roomType);
        Debug.Log("Visibility: " + visToggle.isOn);
        form.AddField("kurationName",kurationNameField.text);
        form.AddField("kuratorID",DBManager.ID);
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
        Debug.Log(sub.text);
        if(sub.text[0] == '0')
        {
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
