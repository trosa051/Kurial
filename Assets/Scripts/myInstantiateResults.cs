using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myInstantiateResults : MonoBehaviour
{

    public myKurations bk;
    public GameObject resultTitle;


    // Start is called before the first frame update
    void Start()
    {
        bk = bk.GetComponent<myKurations>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        GameObject[] resultsTagged = GameObject.FindGameObjectsWithTag("result");
        foreach(GameObject res in resultsTagged)
        {res.tag = "Untagged";
        GameObject.Destroy(res);}
        GameObject[] bodTagged = GameObject.FindGameObjectsWithTag("bod");
        foreach(GameObject bes in bodTagged)
        {bes.tag = "Untagged";
        GameObject.Destroy(bes);}

        for (int i = 0; i < bk.roomsAmt; i++){
            var result = Instantiate(resultTitle);
            result.transform.SetParent(this.transform);
            result.transform.localScale = new Vector3(1,1,1);
        }
    }

}
