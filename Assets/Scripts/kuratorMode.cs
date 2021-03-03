using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kuratorMode : MonoBehaviour
{

    public GameObject myPrefab;
    public GameObject spawnPoint;
    public RawImage textureToUse;

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("art2DAnchor");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    // Update is called once per frame
   /* void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {                      
            noAnchor();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {                      
            yesAnchor();
        }
    }*/

    public void noAnchor(){
        GameObject clone = Instantiate(myPrefab, (spawnPoint.transform.position+new Vector3(0,0,0)), spawnPoint.transform.rotation);
        Renderer rend = clone.GetComponent<Renderer> ();
        rend.material.mainTexture = textureToUse.texture;
        //clone.GetComponent<Renderer>().material.mainTexture = textureToUse.texture as Texture;
    }

    public void yesAnchor(){
        Debug.Log(FindClosestEnemy());
        GameObject clone = Instantiate(myPrefab, (FindClosestEnemy().transform.position+new Vector3(0,0,0)), FindClosestEnemy().transform.rotation);
        Renderer rend = clone.GetComponent<Renderer> ();
        rend.material.mainTexture = textureToUse.texture;
    }
}


///////////////////////////////////////////////////
// Find the name of the closest enemy
// https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
