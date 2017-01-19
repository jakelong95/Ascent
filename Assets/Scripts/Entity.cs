using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {

	public float hitPoints {get; set;}

	public void takeDamage(float damage){
		Debug.Log (hitPoints);
		this.hitPoints -= damage;
		if (this.hitPoints <= 0) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
		
	// Update is called once per frame
	void Update () {
	
	}
}
