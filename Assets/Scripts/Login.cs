using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void callLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        Debug.Log("Attempting to login user: " + nameField.text);
        form.AddField("Email",nameField.text);
        form.AddField("password",passwordField.text);
        var sub = new WWW("https://kurial.space/sqlconnect/login.php",form);
        yield return sub;
        Debug.Log(sub.text);
        if(sub.text[0] == '0')
        {
            DBManager.username = nameField.text;
            Debug.Log("Succesfully logged in. Welcome " + DBManager.ID + "!");
            DBManager.ID = sub.text.Split('\t')[1];
            DBManager.AccStanding = char.Parse(sub.text.Split('\t')[2]);            
            DBManager.LastLog = sub.text.Split('\t')[3];
            SceneManager.LoadScene(5);
        }
        else
        {
            Debug.Log("User login failed. Error #" + sub.text);
        }

    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
