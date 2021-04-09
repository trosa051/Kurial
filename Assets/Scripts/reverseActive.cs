/*
  Author        :    TJ Rosario-Rosa
  Project		:	 Kurial
  Creation Date :    ?
  Due Date		:    ?
  Course		:    CSC 355
  Professor Name:    Dr. Hussain
  Assignment	:    Capstone
  Filename		:    activeOnDisable.cs
  Purpose		:    ?
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reverseActive : MonoBehaviour
{
    public void onClick()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}