using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leepy2 : MonoBehaviour {
	//public float speed = 10.0F;
	//public float rotationSpeed = 100.0F;
	void Update() {
		//float translation = Input.GetAxis("Vertical") * speed;
		//float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		//translation *= Time.deltaTime;
		//rotation *= Time.deltaTime;
		transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime, 0f, 0f);
		//transform.Rotate(0, rotation, 0);
	}
}