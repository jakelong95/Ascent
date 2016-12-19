using UnityEngine;
using UnityEngine.UI;

public class KeyButton : MonoBehaviour {

	public KeyCode key;
	public Button button;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(key)) {
			button.onClick.Invoke();
		} 
	}
}
