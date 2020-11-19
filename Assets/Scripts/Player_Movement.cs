//Harsh Shah

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public camera_controller cam_con;//gets the camera controller script to see if game is paused

    public GameObject hud;
    public GameObject menu;

    public float speed = 6.0f;          //determines how fast the character can move
    public float gravity = -9.8f;       //we need to set some form of gravity for the player object

    private CharacterController _charController;   //gain control of the player's character component

    // Use this for initialization
    void Start ()
    {
        _charController = GetComponent<CharacterController>();  //initialize the character controller to that of the player
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!cam_con.paused)//checks if the game is not paused 
        {
        float deltaX = Input.GetAxis("Horizontal") * speed; //gets the horizontal input from the A and D keys or right and left keys
        float deltaZ = Input.GetAxis("Vertical") * speed;   //gets the vertical input from the W and S keys or up and down arrows
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);   //limits the speed of the player
 
        movement.y = gravity;

        movement *= Time.deltaTime; // ensures the speed the player moves does not change based on frame rates
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
        hud.SetActive(true);//enables onscreen display if game isn't paused
        menu.SetActive(false);//disables inventory/pause screen if game isn't paused
        }
        else
        {
        hud.SetActive(false); //disables onscreen display if game is paused
            menu.SetActive(true);//enables inventory/pause screen if game is paused
        }
	}
}
