using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {

	private Movement mov;

	// Use this for initialization
	void Start () {
		mov = GameObject.FindGameObjectWithTag ("Player").GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			StartCoroutine (mov.Respawn());
		}
	}
}
