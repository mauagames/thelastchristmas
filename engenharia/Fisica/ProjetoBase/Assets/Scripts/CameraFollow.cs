using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject player;

	void LateUpdate () {
		this.transform.SetPositionAndRotation (new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z), player.transform.rotation);
	}
}
