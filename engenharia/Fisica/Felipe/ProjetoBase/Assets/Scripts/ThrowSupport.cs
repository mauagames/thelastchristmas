using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSupport : MonoBehaviour {

	[Header ("Declarations:")]
	public GameObject mainCamera;
	public GameObject player;

	[Header ("Support Status:")]
	public bool aiming;
	public bool charging;
	public bool active;

	[Header ("Aim Status:")]
	public GameObject aimGO;
	public AnimationCurve aimCurveX;
	public AnimationCurve aimCurveY;
	public AnimationCurve aimCurveRotation;

	[Header ("Throw Properties:")]
	public float angle;
	public AnimationCurve chargeForce;
	public float throwForce;
	public bool touchedGround;

	[Header ("Change Back Options:")]
	public float range;
	public LayerMask playerLayer;

	private float T;

	// Use this for initialization
	void Start () {
		aimGO.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		aimGO.GetComponent<Animator> ().SetBool("charging", charging);

		if (aiming) {
			GetComponentInChildren<SpriteRenderer> ().enabled = false;
			aimGO.SetActive (true);
			player.GetComponent<Movement> ().canMove = false;
			touchedGround = false;
			//Aiming variantion
			if (T >= 3)
				T = 0;

			T += Time.deltaTime;
			aimGO.transform.localPosition = new Vector3 (
				aimCurveX.Evaluate(T),
				aimCurveY.Evaluate(T),
				aimGO.transform.localPosition.z
			);
			aimGO.transform.localRotation = Quaternion.Euler (new Vector3(
				aimGO.transform.localRotation.x,
				aimGO.transform.localRotation.y,
				aimCurveRotation.Evaluate(T)
			));
			//Debug.Log (aimCurveX.Evaluate(T) + " | " + aimCurveY.Evaluate(T));
			if (Input.GetKeyUp(KeyCode.Z)) {
				charging = true;
				angle = aimGO.transform.localRotation.eulerAngles.z;
			}
		}

		if (charging) {
			player.GetComponent<Movement> ().canMove = false;
			aiming = false;
			T = 0;

			if (Input.GetKeyDown(KeyCode.Z)) {
				throwSupport ();
				active = true;
			}
		}

		if (active) {
			charging = false;
			aimGO.SetActive (false);
			mainCamera.GetComponent<CameraFollow> ().setPlayer (this.gameObject);
			player.GetComponent<Movement> ().canMove = false;

			if (touchedGround) {
				this.GetComponent<Movement> ().canMove = true;
				mainCamera.GetComponent<CameraFollow> ().setPlayer (this.gameObject);
			}

			if (Physics2D.OverlapCircle (transform.position, range, playerLayer) && Input.GetKeyUp(KeyCode.Z) && touchedGround) {
				this.GetComponent<Movement> ().canMove = false;
				player.GetComponent<Movement> ().canMove = true;
				mainCamera.GetComponent<CameraFollow> ().setPlayer (player.gameObject);
				touchedGround = false;
				active = false;
			}
		}
			
	}

	private void throwSupport() {
		Rigidbody2D rb2d = this.GetComponent<Rigidbody2D> ();
		float forceX = chargeForce.Evaluate (aimGO.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime) * Mathf.Abs(Mathf.Cos(angle)) * throwForce * player.transform.localScale.x;
		float forceY = chargeForce.Evaluate (aimGO.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime) * Mathf.Abs(Mathf.Sin (angle)) * throwForce;
		this.transform.position = player.transform.position;
		//Debug.Log ("X: " + forceX + " | Y: " + forceY);
		rb2d.AddForce (new Vector2 (forceX, forceY), ForceMode2D.Impulse);
		GetComponentInChildren<SpriteRenderer> ().enabled = true;
	}

	void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere (this.transform.position, range);
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.CompareTag ("Floor") || col.gameObject.CompareTag ("Crate"))
			touchedGround = true;
	}

	void OnCollisionStay2D (Collision2D col) {
		if (col.gameObject.CompareTag ("Floor") || col.gameObject.CompareTag ("Crate"))
			touchedGround = true;
	}
}
