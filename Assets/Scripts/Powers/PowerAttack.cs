using UnityEngine;
using System.Collections;
using UnityEngine.UI;

	public class PowerAttack : Power {

	// Use this for initialization
	void Start () {
		base.start ();
	}

	public override void use (Player playerUsingAbility)
	{
		if (!isOnCooldown) {
			Debug.Log ("Used Power Attack");
			StartCoroutine (Cooldown ());
		}
	}

	// Update is called once per frame
	void Update () {
		base.update ();
	}
}
