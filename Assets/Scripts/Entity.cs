using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {

	public int hitPoints {get; set;}

	public void takeDamage(int damage){
		this.hitPoints -= damage;
	}

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("Collision detected");
		if (col.gameObject.tag.Equals("Attack")) {

			//TODO take damage.
			Debug.Log("Hit");
			Destroy (col.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
