using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeepyTrampoline : MonoBehaviour {
	float starttime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.deltaTime-starttime < 10) {
			transform.Translate(0,Time.deltaTime*6,0);
		}	
	}

	void OnCollisionEnter(Collision col){
		if (col.collider.name == "trampoline"){
			starttime = Time.deltaTime;
		}
	}
}
