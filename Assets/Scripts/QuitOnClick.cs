//Katie

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour
{
    //stops the game even when in unity editor
    public void OnApplicationQuit()
    {
# if UNITY_EDITOR //If the game is running from the unity editor
        UnityEditor.EditorApplication.isPlaying = false; //Boots out of editor
#else // If the game is a standalone build 
            Application.Quit(); // Ends game
#endif

    }
}