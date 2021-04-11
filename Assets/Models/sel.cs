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
    public int kurationView = -1;


    // Start is called before the first frame update
    void Start()
    {
         DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
//GameObject.Find("ECM_FirstPerson").GetComponent("_roomPickScript.cs")