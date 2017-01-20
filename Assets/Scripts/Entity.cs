using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {

	public Texture2D healthbar;
	public float hitPoints {get; set;}
	protected float maxHealth;
	protected float healthBarHeight = 5.0f;

	public void takeDamage(float damage){
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
		Debug.Log (healthbar);
	}
		
	void OnGUI(){
		//GUI.DrawTexture(new Rect(transform.position.x, transform.position.y , hitPoints*10, 50), healthbar);
	}
}
