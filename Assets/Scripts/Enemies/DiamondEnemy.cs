using UnityEngine;
using System.Collections;

public class DiamondEnemy : Enemy {

	// Use this for initialization
	void Start () {
		hitPoints = 1.5f * damages.LOW_DAMAGE;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
