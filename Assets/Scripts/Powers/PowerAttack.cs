using UnityEngine;
using System.Collections;
using UnityEngine.UI;


	public class PowerAttack : Power {

	public float scaleLimit = 2.0f;

	// Use this for initialization
	void Start () {
		base.start ();
	}

	public override void use (Player playerUsingAbility)
	{
		if (!isOnCooldown) {
			Debug.Log ("Used Power Attack");
			StartCoroutine (Cooldown ());

            Vector3 shootDirection = Input.mousePosition;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            Vector3 startingLocatoin = playerUsingAbility.transform.position;

            

            Debug.DrawLine(playerUsingAbility.transform.position, shootDirection, Color.white, 20.0f, false);




        }
    }

    public override void IfActivePower()
    {
        //TODO draw cone of hit.
        if (!isOnCooldown)
        {
            Debug.Log("Hit");
        }
    }

    // Update is called once per frame
    void Update () {
		base.update ();
	}
}
