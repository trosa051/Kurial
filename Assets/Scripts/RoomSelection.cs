/*
  Author        :    TJ Rosario-Rosa
  Project		:	 Kurial
  Creation Date :    ?
  Due Date		:    ?
  Course		:    CSC 355
  Professor Name:    Dr. Hussain
  Assignment	:    Capstone
  Filename		:    activeOnDisable.cs
  Purpose		:    allows the user to select a room to enter
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSelection : MonoBehaviour
{
    public enum Name
    {
        TJ,
        Colton,
        Tony,
        Reed,
        Jeff,
        dflt
    }

    [SerializeField]
    Dropdown roomType = null;
    [SerializeField]
    GameObject[] Sels = null;

    public sel choice;
    public GameObject selectionObj;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject i in Sels){
        i.SetActive(true);
        i.SetActive(false);
    }

        roomType.value = 0;
        selectionObj = GameObject.Find("_manager");
        choice = selectionObj.GetComponent<sel>();
        Changed();
    }
    void OnEnable(){
        roomType.value = 0;
        choice = selectionObj.GetComponent<sel>();
        choice.kurID = -1;
        Changed();
    }

    // Update is called once per frame
    public void Changed()
    {
    //Debug.Log(roomType.captionText.text+" has been selected.");
    
    foreach (GameObject i in Sels){
        i.SetActive(false);
    }

    switch (roomType.value)
      {
        case 0:
            Sels[0].SetActive(true);
            choice.setRoom = sel.Name.TJ;
            break;
        case 1:
            Sels[1].SetActive(true);
            choice.setRoom = sel.Name.Colton;
            break;
        case 2:
            Sels[2].SetActive(true);
            choice.setRoom = sel.Name.Tony;
            break;
        case 3:
            Sels[3].SetActive(true);
            choice.setRoom = sel.Name.Reed;
            break;
        case 4:
            Sels[4].SetActive(true);
            choice.setRoom = sel.Name.Jeff;
            break;        
        case 5:
            Sels[5].SetActive(true);
            choice.setRoom = sel.Name.dflt;
            break;
          default:
            Debug.Log("Default case");
            choice.setRoom = sel.Name.dflt;
            break;
      }
      //Sels[roomType.value].SetActive(true);
    }

    public void TaskOnClick()
    {
        //SceneManager.LoadScene(2);
    /*switch (roomType.value)
    {
        case 0: //2
            SceneManager.LoadScene(2);
            break;
        case 1:
            SceneManager.LoadScene(3);
            break;
        case 2:
            SceneManager.LoadScene(4);
            break;
        case 3:
            SceneManager.LoadScene(5);
            break;
        case 4:
            SceneManager.LoadScene(6);
            break;        
        case 5:
            SceneManager.LoadScene(7);
            break;
        default:
            Debug.Log("Nope, Chuck Testa");
            break;
        }*/
    }
}
 

 /*
 Notes for self:

 This is where I can append the correct information to transfer the right prefab info into the scene
 */