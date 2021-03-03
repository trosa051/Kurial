using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class placementScript : MonoBehaviour
{
    public Toggle isAnchor;
    public kuratorMode km;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void pick()
    {
        if (isAnchor.isOn)
        {
            km.yesAnchor();
        }
        else if(!isAnchor.isOn)
        {
            km.noAnchor();
        }
    }
}
