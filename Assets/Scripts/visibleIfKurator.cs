using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class visibleIfKurator : MonoBehaviour
{
    public string resultKurator;
    public GameObject editButton;
    // Start is called before the first frame update
    public void CheckName()
    {
        
        if (DBManager.username != resultKurator)
        {
            editButton.SetActive(false);
        }
        else
        {
            editButton.SetActive(true);
        }
    }

}
