using UnityEngine;
using System.Collections;
using UnityEngine.UI;

	public class PowerAttack : Power {

	// Use this for initialization
	void Start () {
		button.onClick.AddListener (onButtonClick);
	}


	public override void use ()
	{
		if (!isOnCooldown) {
			Debug.Log ("Used Power Attack");
		}
	}

	protected virtual void onButtonClick() {
		Debug.Log ("Clicked BUtton");
		Debug.Log (button);
		//Player.selected.icon.enabled = false;
		sel.enabled = true;
		StartCoroutine (Cooldown ());
	}

	protected virtual IEnumerator Cooldown()
	{
		// Deactivate myButton
		isOnCooldown = true;
		button.interactable = false;

		// Wait for cooldown duration
		yield return new WaitForSeconds(cooldownDuration);

		// Reactivate myButton
		button.interactable = true;
		isOnCooldown = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(key)) {
			button.onClick.Invoke();
		} 

		if (isOnCooldown) {
			icon.fillAmount += Time.deltaTime / cooldownDuration;
			if (icon.fillAmount >= 1) {
				icon.fillAmount = 0;
			}
		}
	}
}
