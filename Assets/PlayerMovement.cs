using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6f; //the speed of movement for the player

	Vector3 movement; //store the direction of the player's movement
	Animator anim; //reference to the animator component
	Rigidbody playerRigidbody; //reference to the player rigidbody
	int floorMask; //a layer so that a ray can be cast at game objects sitting on this floor layer
	float camRayLength = 100f; //the length of the ray from the camera cast into our scene

	// Use this for initialization
	void Awake () {
		//get the layer mask
		floorMask = LayerMask.GetMask("Floor");

		//set up references
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//store the input axes
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		//move the player around by applying force
		Move(h, v);

		//turn the player to face the cursor
		//Turning();

		//animate the player
		Animating(h, v);
	}

	void Move (float h, float v) {
		//set the movement vector based on axis input; y is always 0 cause no jumping
		movement.Set (h, 0f, v);

		//normalize the movement vector and make it proportional to the speed per second
		movement = movement.normalized*speed*Time.deltaTime;

		//update the player to its current position plus movmeent
		playerRigidbody.MovePosition(transform.position + movement);
	}

	void Animating (float h, float v) {
		//create a boolean variable that can only be true or false
		bool walking = h != 0f || v != 0f;

		//tell the animator whether or not the player is walking
		anim.SetBool("IsWalking", walking);
	}
}
