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
		GUI.DrawTexture(new Rect(transform.position.x, transform.position.y , hitPoints*10, 50), healthbar);
	}
}
