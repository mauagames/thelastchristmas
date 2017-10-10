using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	public Vector2 ajuste;

	void LateUpdate () {
		this.transform.SetPositionAndRotation (new Vector3(player.transform.position.x + ajuste.x, this.transform.position.y + ajuste.y, this.transform.position.z), player.transform.rotation);
	}

	public void setPlayer(GameObject pl) {
		this.player = pl;
	}
}
