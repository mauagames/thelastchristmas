using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public Vector3 spawnPoint;
	public float velocity;
	public float jumpForce;
	[HideInInspector]
	public Rigidbody2D rb;
	public bool canJump = false;
	public bool doubleJump = false;
	public float speed;
	private bool receiveInput;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		spawnPoint = this.transform.position;
		receiveInput = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (!receiveInput)
			return;
		/*
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Translate ( new Vector3(velocidade * Time.deltaTime, 0f, 0f));
			this.GetComponent<SpriteRenderer> ().flipX = false;
			print ("Direita");
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Translate ( new Vector3(-velocidade * Time.deltaTime, 0f, 0f));
			this.GetComponent<SpriteRenderer> ().flipX = true;
			print ("Esquerda");
		}
		*/

		double h = Input.GetAxis ("Horizontal");
		//double v = Input.GetAxis ("Vertical");
		if (h < 0) {
			this.transform.localScale = new Vector3 (-1, 1, 1);
		} else if (h > 0) {
			this.transform.localScale = new Vector3 (1, 1, 1);
		}

		speed = (float)(h * velocity * Time.deltaTime);
		transform.Translate ( new Vector2(speed, 0f));

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (canJump) {
				rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
				doubleJump = true;
			} else if (doubleJump) {
				rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
				doubleJump = false;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.CompareTag ("Floor") || col.gameObject.CompareTag ("Crate")) {
			canJump = true;
			doubleJump = false;
		}
	}

	void OnCollisionStay2D (Collision2D col) {
		if (col.gameObject.CompareTag ("Floor") || col.gameObject.CompareTag ("Crate")) {
			canJump = true;
		}
	}

	void OnCollisionExit2D (Collision2D col) {
		if (col.gameObject.CompareTag ("Floor") || col.gameObject.CompareTag ("Crate")) {
			canJump = false;
		}
	}

	public IEnumerator Respawn() {
		receiveInput = false;
		yield return new WaitForSeconds (1);
		this.transform.position = spawnPoint;
		yield return new WaitForSeconds (1);
		receiveInput = true;
	}

}
