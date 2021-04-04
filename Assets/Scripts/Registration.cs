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

    public GameObject passwordWarning;

    public Button submitButton;

    public void callRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        Debug.Log("Attempting to add user: " + nameField.text);
        form.AddField("AccountName",nameField.text);
        form.AddField("Email",emailField.text);
        form.AddField("password",passwordField.text);
        // register.php has been moved to public_html/php
        // var sub = new WWW("https://kurial.space/sqlconnect/register.php",form);
        var sub = new WWW("https://kurial.space/php/register.php", form);
        yield return sub;
        if (sub.text == "0")
        {
            Debug.Log("User created successfully.");
            SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User created falied. Error #" + sub.text);
        }
    }

    public void VerifyInputs()
    {
        passwordWarning.SetActive(!(passwordField.text == confirmPWField.text));
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8 && passwordField.text == confirmPWField.text);
    }
}
