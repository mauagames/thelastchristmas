using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	#region singleton
	public static GameController instance;

	void Awake() {
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}
	#endregion

	private ChangePlayer player;
	private ChangePlayer ally;

	public bool canSwitch;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<ChangePlayer>();
		ally = GameObject.FindGameObjectWithTag ("Ally").GetComponent<ChangePlayer>();
		player.hidden = false;
		ally.hidden = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.Z) && canSwitch) {
			player.tempPosition = ally.transform.position;
			ally.tempPosition = player.transform.position;
			canSwitch = false;
			player.hidden = !player.hidden;
			ally.hidden = !ally.hidden;
			player.switching = true;
			ally.switching = true;
		}

		if (!player.switching && !ally.switching)
			canSwitch = true;
	}
}
