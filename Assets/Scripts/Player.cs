using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	Rigidbody2D rb;
	AudioSource wingAud;
	AudioSource hitAud;
	AudioSource coinAud;
	Vector3 inicialPosition;
	
	public float force = 100f;
	public bool isAlive = true;
	public bool isStarted = false;
	public int points = 0;
	public Text pointText;
	public Button btnStart;
	
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
		wingAud = GetComponents<AudioSource> () [0];
		hitAud = GetComponents<AudioSource> () [1];
		coinAud = GetComponents<AudioSource> () [2];
		inicialPosition = transform.position;
	}
	
	// Update is called once per frame
	// FixedUpdate is used for physical objects
	void FixedUpdate () {
		if(isStarted == true) {
				
			// The 0 are related to the mouse left button
			if (Input.GetMouseButtonDown(0) && isAlive == true) {
				rb.AddForce (new Vector2 (0, force));
				wingAud.Play();
			}
			
			// Rotation are passed in Quaternion, and Euler are a convertion
			if (rb.velocity.y > 0) {
				transform.rotation = Quaternion.Euler (0, 0, 5);
			} else if (rb.velocity.y < 0 ) {
				transform.rotation = Quaternion.Euler (0, 0, -45);
			} else {
				transform.rotation = Quaternion.Euler (0, 0, 0);
			}
			
		} else {
			rb.velocity = Vector2.zero;
			transform.position = inicialPosition;
		}
		
	}
	// coll.gameObject.name == "ground"
	void OnCollisionEnter2D(Collision2D coll) {
		if( (coll.transform.CompareTag ("Pipe") || coll.transform.CompareTag ("Ground")) && isAlive == true) {
			hitAud.Play();
			isAlive = false;
			btnStart.gameObject.SetActive(true);
		}
	}
	
	void OnTriggerEnter2D(Collider2D trig) {
		if (trig.transform.CompareTag ("Point") && isAlive == true) {
			coinAud.Play();
			points = points + 1;
			pointText.text = points.ToString();
		}
	}
	
	public void OnGameStart () {
		foreach(var item in GameObject.FindGameObjectsWithTag("Pipe")){
			GameObject.Destroy (item);
		}
		points = 0;
		pointText.text = points.ToString();
		transform.position = inicialPosition;
		isAlive = true;
		rb.velocity = Vector2.zero;
		isStarted = true;
		btnStart.gameObject.SetActive(false);
	}
}
