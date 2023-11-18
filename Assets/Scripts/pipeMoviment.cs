using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMoviment : MonoBehaviour {

	public float speed = 0.2f;
	Player player;
	
	void Start () {
		player = GameObject.Find("player").GetComponent<Player> ();
	}
	
	// Time.deltaTime calculate the time since the last frame
	void Update () {
		if (player.isAlive == true) {
			Vector3 positionPipe = transform.position;
			positionPipe.x = positionPipe.x - speed + Time.deltaTime;
			transform.position = positionPipe;
			
			if (transform.position.x < -5f) {
				GameObject.Destroy (gameObject);
			}
		}
	}
}
