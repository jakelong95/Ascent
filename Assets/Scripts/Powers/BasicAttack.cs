using UnityEngine;
using System.Collections;
using UnityEngine.UI;

	public class BasicAttack : Power {

	public GameObject bulletFab;

	// Use this for initialization
	void Start () {
		base.start ();
	}

	public override void use ()
	{
		if (!isOnCooldown) {
			Debug.Log ("Used Basic Attack");
			StartCoroutine (Cooldown ());


			//Vector3 position = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
			//GameObject bullet = (GameObject)Instantiate (bulletFab, transform.position, Quaternion.identity);
			//bullet.transform.LookAt (position);
			//bullet.GetComponent<Rigidbody2D>().AddForce (bullet.transform.forward * 1000);

		}
	}

	
	// Update is called once per frame
	void Update () {
		base.update ();
	}
}
