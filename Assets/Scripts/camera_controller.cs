//Prithvi pablani

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this code controls the camera and pauses the game
public class camera_controller : MonoBehaviour
{
    public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseX;    //refers to the enum above

    public float sensHorizontal = 5.0f;     // sensitivity for the horizontal looking movement
    public float sensVertical = 5.0f;       // sensitivity for the vertical looking movement
    public float rotationX = 0;              //the vertical angle the player is looking

    public float minimumVert = -60.0f;     
    public float maximumVert = 60.0f;       

    public bool paused;     //determines whether game is paused or not
    bool fix;                    //an attempt to fix the issue of button click not restoring mouse movement fully

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  //locks the mouse to the center of the screen
        Cursor.visible = false;//makes the cursor disappear
    }

    void OnGUI()            //like update, but for graphics
    {
        GUILayout.BeginVertical();

        if (Input.GetKeyDown(KeyCode.Escape))//pressing escape pauses the game
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            paused = true;
            fix = false;
        }

        if (Input.GetKeyDown(KeyCode.F2) || fix)    //this is where fix gets checked, but still doesn't work
        {
            paused = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            fix = false;
        }
    }

    public void doThis()    //this function is how the button unpauses the game
    {
        fix = true;
    }

    // Update is called once per frame 
    void Update()
    {
        if (!paused)     //checks if game isn't paused
        {
            if (axes == RotationAxis.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
            }
            if (axes == RotationAxis.MouseY)
            {
                rotationX -= Input.GetAxis("Mouse Y") * sensVertical;   //increments the vertical angle based on the mouse's movement
                rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);  //clamps the vertical angle withing the min and max limits

                float rotationY = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
            }
        }
    }
}
