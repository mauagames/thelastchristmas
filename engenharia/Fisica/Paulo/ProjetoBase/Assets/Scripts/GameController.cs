using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	#region singleton

	public static GameController instance;

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

	#endregion

	public int score;

	private ChangePlayer player;
	private ChangePlayer ally;

	[Header ("Can Switch Players 1 and 2:")]
	public bool canSwitch;

	[Header ("Can Throw Player 3:")]
	public bool canThrow;
	public float counter;
	public float limit;

	[Header ("Active Players:")]
	public bool player2;
	public bool player3;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<ChangePlayer> ();
		ally = GameObject.FindGameObjectWithTag ("Ally").GetComponent<ChangePlayer> ();
		player.hidden = false;
		ally.hidden = true;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyUp (KeyCode.Z) && canSwitch &&
		    (GameObject.FindGameObjectWithTag ("Player").GetComponent<Movement> ().canJump ||
		    GameObject.FindGameObjectWithTag ("Ally").GetComponent<Movement> ().canJump) && player2) {
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

		if (Input.GetKey (KeyCode.Z) && player3 && canThrow && ally.hidden) {
			counter += 0.1f;
			if (counter >= limit) {
				//canThrow = false;
				counter = limit;
			}
		} else {
			counter = 0;
		}

	}

}
