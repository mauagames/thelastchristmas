using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public bool canMove;

	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;

	public GameObject player;

	public Vector2 ajust;

	private float posX;
	private float posY;

	void Start ()
	{
		canMove = true;
	}

	void FixedUpdate ()
	{
		if (!canMove)
			return;

		posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX + ajust.x, posY + ajust.y, transform.position.z);
	}

	public void setPlayer (GameObject pl)
	{
		this.player = pl;
	}
}
