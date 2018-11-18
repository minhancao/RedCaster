using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public CharacterController2D controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        /* CONTROL CHANGE */
        if (Input.GetKeyUp(Controls.player.left) || Input.GetKeyUp(Controls.player.right)){
            horizontalMove = 0;
        }
        if (Input.GetKey(Controls.player.left)){
            horizontalMove = -1 * runSpeed;
        } 
        if (Input.GetKey(Controls.player.right)){
            horizontalMove = 1 * runSpeed;
        } 
        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        /* CONTROL CHANGE */
        if(Input.GetKeyDown(Controls.player.jump))
        //if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch")){
            crouch = true;
        }else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }

	}

    void FixedUpdate(){

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
