using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeCreator : MonoBehaviour {

	Player player;
	float clock = 0f;
	
	public GameObject pipeBase;
	public float timerT = 2f;
	public float rangeT = 3.35f;
	public float rangeB = 2.7f;
	
	void Start () {
		player = GameObject.Find ("player").GetComponent<Player> ();
	}
	
	
	void Update () {
		if (player.isAlive == true && player.isStarted == true) {
			clock += Time.deltaTime;
			if(clock >= timerT) {
				clock = 0;
				
				Vector3 pos = transform.position;
				pos.y = pos.y - Random.Range (-rangeT, rangeB);
				// What create, and where
				GameObject.Instantiate (pipeBase, pos, Quaternion.identity);
			}
		}
	}
}
