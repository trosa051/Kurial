//Katie

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//transitions between screens with button click
public class LoadSceneOnClick : MonoBehaviour
{

    // load each scene by an index number given in Build Settings
    public void loadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

    }
}
