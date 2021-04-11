using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultBody : MonoBehaviour
{

    public Text desc;
    public int roomDest = 0;
    //public Int room;
    //bod.transform.SetSiblingIndex(this.transform.GetSiblingIndex()+1);
    //var header = FindObjectsOfType(Transform.GetSiblingIndex());
    // Start is called before the first frame update
    void Start()
    {
        //Set the Sibling Index
        //transform.SetSiblingIndex(m_IndexNumber);
        //Output the Sibling Index to the console
        Debug.Log("Sibling Index : " + transform.GetSiblingIndex());
    }

    // Update is called once per frame
    void OnClick()
    {
        
    }
}
