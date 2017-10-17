using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour {

	public GameObject camera;
	public GameObject otherPlayer;
	public GameObject child;
	[HideInInspector]
	public Rigidbody2D rb;
	private Animator anim;

	public bool hidden;
	public Vector2 posRelative;
	public float speed;

	public bool switching;

	[HideInInspector]
	public Vector3 tempPosition;
	private Vector3 erro = new Vector3 (0.2f, 0.2f, 0f);

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		anim = child.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("switching", switching);

		if (hidden) {
			this.GetComponent<Movement> ().canMove = false;
			if (!switching)
				this.transform.position = new Vector3 (camera.transform.position.x + posRelative.x, camera.transform.position.y + posRelative.y, this.transform.position.z);
		} else {
			this.GetComponent<Movement> ().canMove = true;
		}
			
		if ((this.transform.position.x > (tempPosition.x - erro.x) && this.transform.position.y > (tempPosition.y - erro.y))
			&& (this.transform.position.x < (tempPosition.x + erro.x) && this.transform.position.y < (tempPosition.y + erro.y))) {
			switching = false;
			this.GetComponent<BoxCollider2D> ().enabled = true;
			rb.WakeUp ();
			if (!hidden) {
				camera.GetComponent<CameraFollow> ().setPlayer (this.gameObject);
				this.camera.GetComponent<CameraFollow> ().canMove = true;
			}
		}

		if (switching) {
			rb.Sleep ();
			this.GetComponent<BoxCollider2D> ().enabled = false;
			this.camera.GetComponent<CameraFollow> ().canMove = false;
			float step = speed * Time.deltaTime;
			this.transform.position = Vector3.MoveTowards (this.transform.position, tempPosition, step);
		}
	}
}
