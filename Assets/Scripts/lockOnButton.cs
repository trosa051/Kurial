using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockOnButton : MonoBehaviour
{

        [Tooltip("The keyboard key to lock fields.")]
        [SerializeField]
        private KeyCode _lockKey = KeyCode.Escape;

        [Tooltip("Does the variable start out locked?")]
        [SerializeField]
        private bool _locked;

        [Tooltip("Floats to lock")]
        [SerializeField]
        private Transform[] toLock;

        [Tooltip("Floats to lock")]
        [SerializeField]
        private Transform[] currentNums;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_lockKey))
            _locked = !_locked;

        if (!_locked) {
            for(int i = 0; i < toLock.Length; i++){
                currentNums[i] = toLock[i];
            }
        }
        if (_locked){
            for(int i = 0; i < toLock.Length; i++){
                toLock[i] = currentNums[i];
            }
        }
    }
}
