using UnityEngine;
using System.Collections;
using UnityEngine.UI;

	public class BasicAttack : Power {

	public Rigidbody2D bulletFab;

	// Use this for initialization
	void Start () {
		base.start ();
	}

	public override void use (Player playerUsingAbility)
	{
		if (!isOnCooldown) {
			Debug.Log ("Used Basic Attack");
			StartCoroutine (Cooldown ());


			int speed = 1;
			//...setting shoot direction
			Vector3 shootDirection = Input.mousePosition;
			shootDirection.z = 0.0f;
			shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
			shootDirection = shootDirection-playerUsingAbility.transform.position;
			//...instantiating the rocket
			Rigidbody2D bulletInstance = Instantiate(bulletFab, playerUsingAbility.transform.position, playerUsingAbility.transform.rotation/*Quaternion.Euler(new Vector3(0,0,0))*/) as Rigidbody2D;
			Debug.Log (transform);
			bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);


		}
	}

	
	// Update is called once per frame
	void Update () {
		base.update ();
	}
}
