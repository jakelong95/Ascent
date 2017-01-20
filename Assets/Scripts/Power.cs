using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Power : MonoBehaviour {
	public Image icon;
	public Image sel;
	public Button button;
	public KeyCode key;
	public float cooldownDuration;
	public float distance = 10.0f;

	public const int DAMAGE_LOW = 5;



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
		}
	}

	protected virtual void onButtonClick() {
			//Switch the selected icon.
			Player.selected.sel.enabled = false;
			Player.selected = this;
			Player.selected.sel.enabled = true;
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
			icon.fillAmount = 0;
			button.interactable = true;
			isOnCooldown = false;
		}

	//If this took in a locatoin, we could use the same power for enemies as well.
	//As it stands we grab moues coordinates in this function.
	public virtual void use (Player playerUsingAbility){
		
	}


}
