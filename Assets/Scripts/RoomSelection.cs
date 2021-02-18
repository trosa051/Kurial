using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSelection : MonoBehaviour
{
    [SerializeField]
    Dropdown roomType = null;
    [SerializeField]
    Button vech = null;
    [SerializeField]
    GameObject[] Sels = null;
    
    // Start is called before the first frame update
    void Start()
    {
        roomType.value = 0;
        Changed();
    }

    // Update is called once per frame
    public void Changed()
    {
    Debug.Log(roomType.captionText.text+" has been selected.");
    
    foreach (GameObject i in Sels){
        i.SetActive(false);
    }

    switch (roomType.value)
      {
        case 0:
            Sels[0].SetActive(true);
            break;
        case 1:
            Sels[1].SetActive(true);
            break;
        case 2:
            Sels[2].SetActive(true);
            break;
        case 3:
            Sels[3].SetActive(true);
            break;
        case 4:
            Sels[4].SetActive(true);
            break;
          default:
            Debug.Log("Default case");
            break;
      }
    }

    public void TaskOnClick()
    {
    switch (roomType.value)
    {
        case 0: //3
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
            default:
            Debug.Log("Nope, Chuck Testa");
            break;
        }
    }
}
 

 /*
 Notes for self:

 This is where I can append the correct information to transfer the right prefab info into the scene
 */