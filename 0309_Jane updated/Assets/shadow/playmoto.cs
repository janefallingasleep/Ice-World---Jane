using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playmoto : MonoBehaviour {

	private CharacterController controller;
	private float verticalVelocity;
	private float gravity = 14.0f;
	private float jumpForce = 10.0f;


	// Use this for initialization
	private void Start () {
		controller = GetComponent<CharacterController>();
	}
	// Update is called once per frame
	void Update () {
		if(controller.isGrounded){
			verticalVelocity = -gravity * Time.deltaTime;
			if (Input.GetKeyDown(KeyCode.L)){
				verticalVelocity = jumpForce;
			}

		}
		else{
			verticalVelocity -= gravity * Time.deltaTime;
		}
		Vector3 moveVector = Vector3.zero;
		moveVector.x = Input.GetAxis("Horizontal") * 5.0f;
		moveVector.y = verticalVelocity;
		moveVector.z =  Input.GetAxis("Vertical") * 5.0f;
		controller.Move(moveVector * Time.deltaTime);
	}
}
