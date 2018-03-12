using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadow: MonoBehaviour {
	Animator animator;
	public AudioClip jump1;
	AudioSource shadow_jump;
	Rigidbody Shadow;
	bool jumped = true;
	float jump;
	float rot = 0;
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>(); 
		Shadow = GetComponent<Rigidbody>();
		shadow_jump = GetComponent<AudioSource>();
		controller = GetComponent<CharacterController>();
	}


	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis("Horizontal"); //horizontal means the left key and right key 
		float moveVertical = Input.GetAxis("Vertical"); 
		float speed = Mathf.Sqrt (moveHorizontal * moveHorizontal + moveVertical * moveVertical)*1.0f;
		animator.SetFloat("speed", speed, 0.15f, Time.deltaTime);

		// Translation of the shadow using keyboard arrows
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Shadow.velocity = movement*1.0f;

		// Rotation of the shadow
		float x = moveHorizontal;
		float y = moveVertical;
		if (x != 0 || y != 0) {
			rot = (Mathf.Atan2 (-1*x, -1*y)*Mathf.Rad2Deg) % 360;
		}
		Vector3 rotation = new Vector3 (0,rot+90,0);
		Quaternion deltaRotation = Quaternion.Euler (rotation);
		Shadow.MoveRotation (deltaRotation);

		if (Input.GetKey(KeyCode.J)) {
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
