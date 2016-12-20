using UnityEngine;
using System.Collections;
using UnityEngine.UI;

	public class BasicAttack : Power {

	// Use this for initialization
	void Start () {
		base.start ();
	}

	public override void use ()
	{
		if (!isOnCooldown) {
			Debug.Log ("Used Basic Attack");
			isOnCooldown = true;
		}
	}

	
	// Update is called once per frame
	void Update () {
		base.update ();
	}
}
