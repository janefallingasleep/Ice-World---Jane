using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playmoto : MonoBehaviour {

	private CharacterController controller;
	private float verticalVelocity;
	private float gravity = 14.0f;
	private float jumpForce = 10.0f;

	Animator animator;
	public AudioClip jump1;
	AudioSource shadow_jump;
	Rigidbody Shadow;
	bool jumped = true;
	float jump;
	float rot = 0;

	public float spd;


	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator>(); 
		Shadow = GetComponent<Rigidbody>();
		shadow_jump = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void Update () {
		if(controller.isGrounded){
			verticalVelocity = -gravity * Time.deltaTime;
			if (Input.GetKeyDown(KeyCode.Space)){
				verticalVelocity = jumpForce;
			}

		}
		else{
			verticalVelocity -= gravity * Time.deltaTime;
		}

		float moveHorizontal = Input.GetAxis("Horizontal"); //horizontal means the left key and right key 
		float moveVertical = Input.GetAxis("Vertical"); 
		float speed = Mathf.Sqrt (moveHorizontal * moveHorizontal + moveVertical * moveVertical);
		animator.SetFloat("speed", speed, 0.15f, Time.deltaTime);

		// Translation of the shadow using keyboard arrows
		Vector3 movement = new Vector3 (-1*moveVertical, verticalVelocity*0.3f, moveHorizontal);
		//Shadow.velocity = movement*1.0f;
		controller.Move(movement * Time.deltaTime*spd);

		// Rotation of the shadow
		float x = moveHorizontal;
		float y = moveVertical;
		if (x != 0 || y != 0) {
			rot = (Mathf.Atan2 (-1*x, -1*y)*Mathf.Rad2Deg) % 360;
		}
		Vector3 rotation = new Vector3 (0,rot+90,0);
		Quaternion deltaRotation = Quaternion.Euler (rotation);
		//Shadow.MoveRotation (deltaRotation);
		transform.rotation = deltaRotation;

		if (Input.GetKey(KeyCode.Space)) {
			animator.SetTrigger("jumptrigger");

			if (jumped == true) {
				jump = Time.deltaTime;
				jumped = false;
			}
		}
		if (jumped == false && Time.deltaTime - jump > 0.1f) {
			shadow_jump.PlayOneShot(jump1,1F);
			jumped = true;
		}
		if (Input.GetKey(KeyCode.D)){
			animator.SetTrigger("dance");
		}
	}
}
