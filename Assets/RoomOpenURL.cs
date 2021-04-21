using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomOpenURL : MonoBehaviour
{
    enum Name
    {
        TJ,
        Colton,
        Tony,
        Reed,
        Jeff,
        dflt
    }

    string sceneID = "";
    sel go;
    // Start is called before the first frame update
    void Start()
    {
        //selectionObj = GameObject.Find("_manager");
        go = GameObject.Find("_manager").GetComponent<sel>();


        //Expected Output https://kurial.space/?kuration=XXXX
        Debug.Log(Application.absoluteURL);
        
        sceneID = Application.absoluteURL.Split('=')[1];
        //Expected Output XXXX
        Debug.Log(sceneID);
        if(sceneID != ""){
        callLetsGo();
        }
    }

    void callLetsGo(){
        StartCoroutine(LetsGo());
    }

    IEnumerator LetsGo()
    {
        WWWForm form = new WWWForm();
        Debug.Log("Attempting to go to kuration #" + sceneID);
        form.AddField("idWord",sceneID);
        var sub = new WWW("https://kurial.space/php/getRoom.php",form);
        yield return sub;
        if (sub.text[0] == '0')
        {
            Debug.Log("Room found successfully.");
            //SceneManager.LoadScene(0);
            Debug.Log(sub.text.Split('\t')[1]);
            go.setRoom = (sel.Name)Int32.Parse(sub.text.Split('\t')[1]);
            go.kurID = Int32.Parse(sceneID);
            go.editing = false;
            SceneManager.LoadScene(2);
        }
        else if (sub.text[0] != '0')
        {
            Debug.Log("User created falied. Error #" + sub.text);
        }
        //return (IEnumerable)new List<String>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
