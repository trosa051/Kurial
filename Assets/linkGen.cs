using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class linkGen : MonoBehaviour
{
    public InputField inFi;
    sel go;

    void Start()
    {
        go = GameObject.Find("_manager").GetComponent<sel>();
        inFi.text = inFi.text+go.kurID;
    }

}
