/*
  Author        :    TJ Rosario-Rosa
  Project		:	 Kurial
  Creation Date :    ?
  Due Date		:    ?
  Course		:    CSC 355
  Professor Name:    Dr. Hussain
  Assignment	:    Capstone
  Filename		:    LoadSceneOnClick.cs
  Purpose		:    Used to transition between scenes
*/
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

    public void editable(bool canEdit)
    {
      sel choice = GameObject.Find("_manager").GetComponent<sel>();
      choice.editing = canEdit;
    }
}
