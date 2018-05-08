using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour {

	[Header ("Declarations:")]
	public GameObject mainCamera;
	public GameObject otherPlayer;
	public GameObject child;
	[HideInInspector]
	public Rigidbody2D rb;

	[Header ("Player Status:")]
	public bool hidden;
	public bool switching;

	[Header ("Hidden Position:")]
	public Vector2 posRelative;

	[Header ("Change Speed:")]
	public float speed;

	public AnimationCurve curveIn;

	[HideInInspector]
	public Vector3 tempPosition;
	private Vector3 erro = new Vector3 (0.2f, 0.2f, 0f);
	private float T;

	//public float y;
	//public float ycerto;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (hidden) {
			this.GetComponent<Movement> ().canMove = false;
			if (!switching)
				this.transform.position = new Vector3 (mainCamera.transform.position.x + posRelative.x, mainCamera.transform.position.y + posRelative.y, this.transform.position.z);
		} else {
			this.GetComponent<Movement> ().canMove = true;
		}
			
		if ((this.transform.position.x >= (tempPosition.x - erro.x) && this.transform.position.y >= (tempPosition.y - erro.y))
			&& (this.transform.position.x <= (tempPosition.x + erro.x) && this.transform.position.y <= (tempPosition.y + erro.y)) && switching) {
			this.GetComponent<BoxCollider2D> ().enabled = true;
			T = 0f;
			rb.WakeUp ();
			if (!hidden) {
				mainCamera.GetComponent<CameraFollow> ().setPlayer (this.gameObject);
				this.mainCamera.GetComponent<CameraFollow> ().canMove = true;
			}
			switching = false;
		}

		if (switching) {
			this.GetComponent<Movement> ().canMove = false;
			T += Time.deltaTime;
			Vector3 curPos =  new Vector3(
				this.transform.position.x, 
				this.transform.position.y + curveIn.Evaluate (T),
				this.transform.position.z
			);
			//y = this.transform.position.y;
			//ycerto = this.transform.position.y + curveIn.Evaluate (T);
			//Debug.Log ("gb: " + this.name + " | Y: " + y + " | Y certo: " + ycerto + " | Evaluate: " + curveIn.Evaluate(T) );
			//curPos.y = this.transform.position.y + curveIn.Evaluate (T);
			//Debug.Log ("PosY: " +  this.transform.position.y + " | Evaluate: " + curveIn.Evaluate(T)  +  " | Resultado: " + curPos.y);
			rb.Sleep ();
			this.GetComponent<BoxCollider2D> ().enabled = false;
			this.mainCamera.GetComponent<CameraFollow> ().canMove = false;
			float step = speed * Time.deltaTime; //speed * curveIn.Evaluate (Time.deltaTime) * transform.position.y; //speed * Time.deltaTime;
			this.transform.position = Vector3.MoveTowards (curPos, tempPosition, step);
		}
	}
}
