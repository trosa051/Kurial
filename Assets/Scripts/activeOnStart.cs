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
