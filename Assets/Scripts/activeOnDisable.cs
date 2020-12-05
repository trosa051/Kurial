using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeOnDisable : MonoBehaviour
{
    [SerializeField]
    private bool wakeActive = false;

    void OnDisable()
    {
        gameObject.SetActive(wakeActive);
    }
}