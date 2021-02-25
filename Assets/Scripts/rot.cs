/*
  Author        :    TJ Rosario-Rosa
  Project		:	 Kurial
  Creation Date :    ?
  Due Date		:    ?
  Course		:    CSC 355
  Professor Name:    Dr. Hussain
  Assignment	:    Capstone
  Filename		:    rot.cs
  Purpose		:    rotates template rooms in selection screen
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot : MonoBehaviour
{
    [SerializeField]
    float xAngle = 1f;
    [SerializeField]
    float yAngle = 1f;
    [SerializeField]
    float zAngle = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }
}
