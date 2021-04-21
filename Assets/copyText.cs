using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyText : MonoBehaviour
{
    sel go;
    string link;

    public void onClick()
    {
        go = GameObject.Find("_manager").GetComponent<sel>();
        link = "https://kurial.space/?kuration="+go.kurID;
        GUIUtility.systemCopyBuffer = link;
        WebGLCopyAndPasteAPI.PassCopyToBrowser(link);
        Debug.Log(link+" Copied to clipboard");
    }
}
