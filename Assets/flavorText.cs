using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flavorText : MonoBehaviour
{
        public Text flavor; 
        public string[] quips;

    // Start is called before the first frame update
    void Start()
    {
        flavor.text = quips[Random.Range(0,quips.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
