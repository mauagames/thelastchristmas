using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] heartSprites;
	public Image heartUi;
	private PlayerStats player; 

	void Start (){

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStats> ();

	}

	void Update (){

		heartUi.sprite = heartSprites[player.curHealth];
	}

}
