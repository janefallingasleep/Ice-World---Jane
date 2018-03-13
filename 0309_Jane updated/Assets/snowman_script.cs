using UnityEngine;
using System.Collections;

public class snowman_script : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "killer_rock") {
			Destroy(this.gameObject);
			Debug.Log ("Snowman killed");
		}
	}
}