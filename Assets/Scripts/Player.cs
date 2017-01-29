using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : Entity {

	public GameObject panel;
	static int numPowers = 2;
	public Power[] powers = new Power[numPowers];
	public static Power selected;

	// Use this for initialization
	void Start () {
		hitPoints = 10;
		selected = powers [0];
		//TODO hide all but first power from displaying on screen
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Power p in powers){//If a hotkey is pressed, select that power.
			if (Input.GetKeyDown (p.key)) {
				p.button.onClick.Invoke ();

			}
		}
			
		//Attack
		if (Input.GetMouseButton (0) && panel.activeSelf && //Is click outside of panelL?
		    !RectTransformUtility.RectangleContainsScreenPoint (
			    panel.GetComponent<RectTransform> (), 
			    Input.mousePosition, 
			    Camera.main)) {
			selected.use (this);
		}

        selected.IfActivePower();
	}

	//Putting this in Entity doesn't call it for some reason.
	void OnGUI(){
		GUI.DrawTexture(new Rect(Camera.main.WorldToScreenPoint(this.transform.position).x - hitPoints * 10 /2, Camera.main.WorldToScreenPoint(this.transform.position).y - 15.0f, hitPoints*10, healthBarHeight), healthbar);
	}
}
