using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sel : MonoBehaviour
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
    public Name setRoom = Name.TJ;
    //public int kurationView = -1;
    public int kurID = -1; //this is the kurationID
    public bool editing = false;

    //public GameObject[] respawns;

    // Start is called before the first frame update
    void Start()
    {
         DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       if (Application.absoluteURL.StartsWith("https://kurial.space/?kuration="))
       {   //disable doors
            GameObject[] doors = GameObject.FindGameObjectsWithTag("door");
            foreach(GameObject i in doors) {i.SetActive(false);}
       }
    }
    void killMe()
    { 
        Destroy(this.gameObject);
    }
}
//GameObject.Find("ECM_FirstPerson").GetComponent("_roomPickScript.cs")