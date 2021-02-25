/*
  Author        :    TJ Rosario-Rosa
  Project		:	 Kurial
  Creation Date :    ?
  Due Date		:    ?
  Course		:    CSC 355
  Professor Name:    Dr. Hussain
  Assignment	:    Capstone
  Filename		:    activeOnStart.cs
  Purpose		:    ?
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activeOnStart : MonoBehaviour
{
    [SerializeField]
    private bool StartActive = false;

    void Start()
    {
        gameObject.SetActive(StartActive);
    }

}
