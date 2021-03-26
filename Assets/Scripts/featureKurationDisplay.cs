using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class featureKurationDisplay : MonoBehaviour
{
    float timeLeft = 10.0f;
    public GameObject[] featKur;
    public int curFeat = 0;


    void Start()
    {
        curFeat = Random.Range(0,featKur.Length);
        foreach(GameObject el in featKur)
        {
            el.SetActive(false);
        }
        featKur[curFeat].SetActive(true);
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            foreach(GameObject el in featKur)
            {
                el.SetActive(false);
            }
            if((curFeat+1) >= featKur.Length){
                curFeat = 0;
            }
            else {curFeat++;}
            featKur[curFeat].SetActive(true);
            //Debug.Log("Switched Feature!");
            timeLeft = 30.0f;
        }
    }
 
}
