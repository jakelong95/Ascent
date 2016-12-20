using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public GameObject panel;
	static int numPowers = 3;
	public Power[] powers = new Power[numPowers];
	public static Power selected;

	// Use this for initialization
	void Start () {
		//TODO define all powers here
		powers[0] = gameObject.AddComponent<BasicAttack>();
		powers [1] = gameObject.AddComponent<PowerAttack>();
		//Why is this 5? THis should be 2.
		powers [2] = gameObject.AddComponent<BasicAttack>();
		powers [3] = gameObject.AddComponent<PowerAttack>();
		powers [4] = gameObject.AddComponent<PowerAttack>();
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
