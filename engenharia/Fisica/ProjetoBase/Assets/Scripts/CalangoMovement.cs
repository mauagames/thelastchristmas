using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalangoMovement : MonoBehaviour {

	public bool oculto;
	public GameObject camera;
	public Vector2 posRelativa;
	[HideInInspector]
	public Rigidbody2D rb;
	public float pushForce;
	public GameObject player;
	public bool trocar;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp (KeyCode.Z) && trocar) {
			trocar = false;
			if (oculto) {
				oculto = false;
				rb.WakeUp ();
				rb.AddForce (new Vector2 (pushForce, 0), ForceMode2D.Impulse);
				//this.camera.GetComponent<CameraFollow> ().setPlayer (this.gameObject);
			} else {
				oculto = true;
				rb.Sleep ();
			}
		}
		if (oculto) {
			this.transform.SetPositionAndRotation (new Vector3 (camera.transform.position.x + posRelativa.x, camera.transform.position.y + posRelativa.y, this.transform.position.z), camera.transform.rotation);
		}
	}
}
