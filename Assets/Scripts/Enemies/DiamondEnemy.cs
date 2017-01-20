using UnityEngine;
using System.Collections;

public class DiamondEnemy : Enemy {

	// Use this for initialization
	void Start () {
		maxHealth = hitPoints = 1.5f * damages.LOW_DAMAGE;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Putting this in Entity doesn't call it for some reason.
	void OnGUI(){
		GUI.DrawTexture(new Rect(Camera.main.WorldToScreenPoint(this.transform.position).x - hitPoints * 10 /2, Camera.main.WorldToScreenPoint(this.transform.position).y - 15.0f, hitPoints*10, healthBarHeight), healthbar);
	}
}
