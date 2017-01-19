using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private float bullet_dmage = damages.LOW_DAMAGE;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		Destroy (gameObject);

		if (col.gameObject.GetComponent (typeof(Entity))) {
			((Entity)col.gameObject.GetComponent(typeof(Entity))).takeDamage (bullet_dmage);
		}
	}


	//Delete bullets that go offscreen.
	void OnBecameInvisible(){
		Destroy(gameObject);
	}
}
