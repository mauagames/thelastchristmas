using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	//vida
	public int maxHealth = 5;
	public int curHealth;
	public GameObject Player;

	// Use this for initialization
	void Start () {
		curHealth = maxHealth;

	}
	
	// Update is called once per frame
	void Update () {
		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}

		if (curHealth <= 0) {
			die ();
		}
	}

	void die(){
		Time.timeScale = 0; // ****Medida temporaria pra fazer o jogo acabar! Mudar dps... Por enquanto só congela qnd a vida = 0*****

	}
}
