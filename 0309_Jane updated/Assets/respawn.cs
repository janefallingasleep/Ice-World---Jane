using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour 
{
	[SerializeField] public Transform player;
	[SerializeField] public Transform camera;
	[SerializeField] public Transform respawnPoint;

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Collides with " + other.gameObject.name);
		if (other.gameObject.name == "shadow_rigged") {
			player.transform.position = respawnPoint.transform.position;
			camera.transform.position = new Vector3 (75f, 2.9f, 25f);
		}
	}
}
