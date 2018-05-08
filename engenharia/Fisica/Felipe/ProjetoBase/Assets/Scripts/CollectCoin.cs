using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoin : MonoBehaviour
{

	private Rigidbody2D rb2d;
	private Animator anim;
	public Text txtScore;
	private GameController gc;

	// Use this for initialization
	void Start ()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		gc = GameController.instance;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag ("CopperCoin")) {
			col.gameObject.SetActive (false);
			gc.score += 10;
			txtScore.text = "Score: " + gc.score;
		}
		if (col.CompareTag ("SilverCoin")) {
			col.gameObject.SetActive (false);
			gc.score += 50;
			txtScore.text = "Score: " + gc.score;
		}
		if (col.CompareTag ("GoldCoin")) {
			col.gameObject.SetActive (false);
			gc.score += 100;
			txtScore.text = "Score: " + gc.score;
		}

	}

}
	