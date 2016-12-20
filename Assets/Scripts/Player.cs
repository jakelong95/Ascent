using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public GameObject panel;
	static int numPowers = 2;
	public Power[] powers = new Power[numPowers];
	public static Power selected;

	// Use this for initialization
	void Start () {
		//TODO define all powers here
		//powers[0] = new PowerAttack();//gameObject.AddComponent<BasicAttack>();
		//powers [1] = gameObject.AddComponent<PowerAttack>();

		//TODO hide all but first power from displaying on screen

		selected = powers [0];
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Power p in powers){//If a hotkey is pressed, select that power.
			if (Input.GetKeyDown (p.key)) {
				p.button.onClick.Invoke ();
			}
		}
			
		//Attack
		if (Input.GetMouseButton (0) && panel.activeSelf && //Is click outside of paneL?
		    !RectTransformUtility.RectangleContainsScreenPoint (
			    panel.GetComponent<RectTransform> (), 
			    Input.mousePosition, 
			    Camera.main)) {
			selected.use ();
		}
	}
}
