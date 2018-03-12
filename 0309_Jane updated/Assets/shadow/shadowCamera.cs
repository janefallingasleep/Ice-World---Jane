using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowCamera : MonoBehaviour {
	private CharacterController controller;
	public float speed;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis("Horizontal"); //horizontal means the left key and right key 
		float moveVertical = Input.GetAxis("Vertical"); 

		// Translation of the shadow using keyboard arrows
		Vector3 movement = new Vector3 (-1*moveVertical, 0, moveHorizontal);
		controller.Move(movement * Time.deltaTime * speed);
	}
}
