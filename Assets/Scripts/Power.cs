using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Power : MonoBehaviour {
	public Image icon;
	public Image sel;
	public Button button;
	public KeyCode key;
	public float cooldownDuration;

	protected bool isOnCooldown = false;

	public void start(){
		button.onClick.AddListener (onButtonClick);
	}

	public void update(){
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

	protected virtual void onButtonClick() {
			Player.selected.icon.enabled = false;
			sel.enabled = true;
	}

		// Coroutine that will deactivate and reactivate the button 
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

	public virtual void use (){
		
	}


}
