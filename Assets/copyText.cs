using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyText : MonoBehaviour
{
    sel go;

    public void onClick()
    {
        go = GameObject.Find("_manager").GetComponent<sel>();
        GUIUtility.systemCopyBuffer = "https://kurial.space/?kuration="+go.kurID;
        //WebGLCopyAndPasteAPI.PassCopyToBrowser("https://kurial.space/?kuration="+go.kurID);
        Debug.Log("https://kurial.space/?kuration="+go.kurID+" Copied to clipboard");
    }
}
