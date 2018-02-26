using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leepy : MonoBehaviour {
	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float speed = Input.GetAxis ("Horizontal");
		animator.SetFloat ("speed", speed, 0.15f, Time.deltaTime);
		if (Input.GetKeyUp (KeyCode.J)) {
			animator.SetTrigger ("jump");
		}
	}
}
