using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
/*
    public Text playerDisplay;
    public Text scoreDisplay;

    private void Awake(){
        if (DBManager.username == null){
            SceneManager.LoadScene(0);
        }
        playerDisplay.text = "Player: " + DBManager.username;
        scoreDisplay.text = "Score: " + DBManager.score;
    }

    public void  CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username);
        form.AddField("score", DBManager.score);

        var sub = new WWW("https://kurial.space/sqlconnect/savedata.php",form);
        yield return sub;
        if(sub.text == "0")
        {
            Debug.Log("Game Saved.");
        }
        else
        {
            Debug.Log("Save failed. Error #" + sub.text);
        }
        DBManager.Logout();
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore(){
        DBManager.score++;
        scoreDisplay.text = "Score: " + DBManager.score;
    }

*/
}
