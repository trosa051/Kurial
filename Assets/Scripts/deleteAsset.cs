using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteAsset : MonoBehaviour
{
    sel go;
    [SerializeField]
    public int ass;
    public GameObject poof;

    public void OnClick()
    {
        go = GameObject.Find("_manager").GetComponent<sel>();
        //ass = go.kurID;
        StartCoroutine(DeleteAsset());
    }
    IEnumerator DeleteAsset()
    {
        WWWForm form = new WWWForm();
        Debug.Log("Attempting to delete asset with ID " + ass);
        form.AddField("assetToDel",ass);
        var sub = new WWW("https://kurial.space/php/delAsset.php",form);
        yield return sub;
        Debug.Log(sub.text);
        if(sub.text[0] == '0')
        {
            Debug.Log("Delete successful.");
            //find poof
            
            Destroy(poof);
            //myKurations reset = GameObject.Find("Browse Helper").GetComponent<myKurations>();
            //reset.callBrowseKuration();
        }
        else
        {
            Debug.Log("Delete unsuccessful.");
        }
    }
}