using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Registration : MonoBehaviour
{
    public InputField nameField;    
    public InputField emailField;
    public InputField passwordField;
    public InputField confirmPWField;

    public Text passwordWarning;

    public Button submitButton;

    public void callRegister()
    {
        Debug.Log("ping");
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        Debug.Log("Attempting to add user: " + nameField.text);
        form.AddField("AccountName",nameField.text);
        form.AddField("Email",emailField.text);
        form.AddField("password",passwordField.text);
        var sub = new WWW("https://kurial.space/php/register.php",form);
        yield return sub;
        Debug.Log(sub.text);
        if(sub.text[1] == '0')
        {
            Debug.Log("User created successfully.");
            SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User created falied. Error #" + sub.text);
            if(sub.text[1] == '3') passwordWarning.text = "Username already taken";
            if(sub.text[2] == 'b') passwordWarning.text = "Email already in use";
            //errmsg.SetActive(true);
        }
    }

    public void VerifyInputs()
    {
        if(passwordField.text != confirmPWField.text) passwordWarning.text = "Passwords do not match!";
        if(passwordField.text == confirmPWField.text) passwordWarning.text = "";
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8 && passwordField.text == confirmPWField.text);
    }
}
