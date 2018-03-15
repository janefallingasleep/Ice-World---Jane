using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanShooting : MonoBehaviour {

	public float speed;
	private Transform player; 
	private Vector3 target;

	void Start () {
		player = GameObject.FindGameObjectWithTag("player").transform;
		target = new Vector3(player.position.x, player.position.y, player.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		if(transform.position.x == target.x && transform.position.z == target.z && transform.position.y == target.y ){
			DestroyProjectile();
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "player") {
			DestroyProjectile();
		}
	}

	void DestroyProjectile(){
		Destroy(gameObject);
	}
}
