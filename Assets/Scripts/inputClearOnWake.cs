/*
  Author        :    TJ Rosario-Rosa
  Project		:	 Kurial
  Creation Date :    ?
  Due Date		:    ?
  Course		:    CSC 355
  Professor Name:    Dr. Hussain
  Assignment	:    Capstone
  Filename		:    activeOnDisable.cs
  Purpose		:    Clears input fields upon update
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputClearOnWake : MonoBehaviour
{
    public InputField inpField;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnEnable()
    {
        
         inpField.text = "";
    }

}
