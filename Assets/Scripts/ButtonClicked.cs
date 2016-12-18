using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClicked : MonoBehaviour {
	public float cooldownDuration;
	public Image img;
	public Button btn;
	private bool cooldown = false;

	// Use this for initialization
	void Start () {
	}

	void Awake(){
		btn.onClick.AddListener (onButtonClick);
	}

	// Update is called once per frame
	void Update () {
		if (cooldown) {
			img.fillAmount += Time.deltaTime / cooldownDuration;
			if (img.fillAmount >= 1) {
				img.fillAmount = 0;
				cooldown = false;
			}
		}

	}
		

	void onButtonClick() {
		StartCoroutine(Cooldown());
	}

	// Coroutine that will deactivate and reactivate the button 
	IEnumerator Cooldown()
	{
		// Deactivate myButton
		btn.interactable = false;
		cooldown = true;
		// Wait for cooldown duration
		yield return new WaitForSeconds(cooldownDuration);
		// Reactivate myButton
		cooldown = false;
		btn.interactable = true;
	}
}



