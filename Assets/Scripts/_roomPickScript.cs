using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _roomPickScript : MonoBehaviour
{

enum Name
    {
        TJ,
        Colton,
        Tony,
        Reed,
        Jeff,
        dflt
    }

    [SerializeField]
    private Name _activeRoom = Name.TJ;

    [SerializeField]
    GameObject[] rooms = new GameObject[6];
    // Start is called before the first frame update

    public GameObject selectionObj;
    public sel choice;

    void Start()
    {
        selectionObj = GameObject.Find("_manager");
        choice = selectionObj.GetComponent<sel>();
        _activeRoom = (Name)choice.setRoom;
        Awake();
    }
    // Update is called once per frame
    void Awake()
    {
        foreach (GameObject i in rooms)
        {
            i.SetActive(false);
        }
        switch(_activeRoom)
        {
        case Name.TJ:
        rooms[0].SetActive(true);
        break;
        case Name.Colton:
        rooms[1].SetActive(true);
        break;
        case Name.Tony:
        rooms[2].SetActive(true);
        break;
        case Name.Reed:
        rooms[3].SetActive(true);
        break;
        case Name.Jeff:
        rooms[4].SetActive(true);
        break;
        default:
        rooms[5].SetActive(true);
        break;
        }   
    }
}
