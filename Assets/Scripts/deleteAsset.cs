using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteAsset : MonoBehaviour
{
    sel go;
    int ass;
    public GameObject poof;

    public void OnClick()
    {
        go = GameObject.Find("_manager").GetComponent<sel>();
        ass = go.kurID;
        StartCoroutine(DeleteAsset());
    }
    IEnumerator DeleteAsset()
    {
        WWWForm form = new WWWForm();
        Debug.Log("Attempting to delete asset with ID " + ass);
        form.AddField("roomToDel",ass);
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