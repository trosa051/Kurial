using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityKuration : MonoBehaviour
{
    sel go;
    int room;
    public GameObject poof;

    public void OnClick()
    {
        go = GameObject.Find("_manager").GetComponent<sel>();
        room = go.kurID;
        StartCoroutine(VisRoom());
    }
    IEnumerator VisRoom()
    {
        WWWForm form = new WWWForm();
        Debug.Log("Attempting to flip visibility of kuration with ID " + room);
        form.AddField("flipVis",room);
        var sub = new WWW("https://kurial.space/php/visKuration.php",form);
        yield return sub;
        Debug.Log(sub.text);
        if(sub.text[0] == '0')
        {
            Debug.Log("Flip successful.");
            //Destroy(poof);
            myKurations reset = GameObject.Find("Browse Helper").GetComponent<myKurations>();
            reset.callBrowseKuration();
        }
        else
        {
            Debug.Log("Flip unsuccessful.");
        }
    }
}