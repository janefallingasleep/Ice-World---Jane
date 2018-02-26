using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadow: MonoBehaviour {
    Animator animator;
	public AudioClip jump1;
	AudioSource shadow_jump;
	Rigidbody Shadow;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>(); 
		Shadow = GetComponent<Rigidbody>();
		shadow_jump = GetComponent<AudioSource>();
	}
		
		
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal"); //horizontal means the left key and right key 
		float moveVertical = Input.GetAxis("Vertical"); 
		float speed = Mathf.Sqrt (moveHorizontal * moveHorizontal + moveVertical * moveVertical);
        animator.SetFloat("speed", speed, 0.15f, Time.deltaTime);
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        Shadow.velocity = movement;
		
        if (Input.GetKey(KeyCode.J)) {
            animator.SetTrigger("jump");
			shadow_jump.PlayOneShot(jump1,1F);
        }
		if (Input.GetKey(KeyCode.D)){
			animator.SetTrigger("dance");
		}
	}
}
