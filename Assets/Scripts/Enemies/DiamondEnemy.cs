﻿using UnityEngine;
using System.Collections;


//These little prickly dudes have basically no health
//And "attack" by running into you. Maybe their attack
//Will stun you or push you back or something.
public class DiamondEnemy : Enemy {

	public Player player; //Target to appraoch. Could have a list of players in GameManager, but this works for now.

	// Use this for initialization
	void Start () {
		maxHealth = hitPoints = 1.5f * damages.LOW_DAMAGE;
	}
	
	// Update is called once per frame
	void Update () {
		//Move to player
		float range = Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y));
		transform.Translate(Vector2.MoveTowards (new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y), range) * speed * Time.deltaTime);
	}

	//Putting this in Entity doesn't call it for some reason.
	void OnGUI(){
		//Health bar
		GUI.DrawTexture(new Rect(Camera.main.WorldToScreenPoint(this.transform.position).x - hitPoints * 10 /2, Camera.main.WorldToScreenPoint(this.transform.position).y - 15.0f, hitPoints*10, healthBarHeight), healthbar);
	}
}
