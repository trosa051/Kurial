using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteKuration : MonoBehaviour
{
    sel go;
    int room;
    public GameObject poof;

    public void OnClick()
    {
        go = GameObject.Find("_manager").GetComponent<sel>();
        room = go.kurID;
        StartCoroutine(DeleteRoom());
    }
    IEnumerator DeleteRoom()
    {
        WWWForm form = new WWWForm();
        Debug.Log("Attempting to delete kuration with ID " + room);
        form.AddField("roomToDel",room);
        var sub = new WWW("https://kurial.space/php/delKuration.php",form);
        yield return sub;
        Debug.Log(sub.text);
        if(sub.text[0] == '0')
        {
            Debug.Log("Delete successful.");
            Destroy(poof);
            myKurations reset = GameObject.Find("Browse Helper").GetComponent<myKurations>();
            reset.callBrowseKuration();
        }
        else
        {
            Debug.Log("Delete unsuccessful.");
        }
    }
}