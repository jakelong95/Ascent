using UnityEngine;
using System;


//Right now the movement works in such a way that the further you are when you click, the faster you go.
//This may not be ideal, but if we get everything ideal, we have a brain full of ideas and nothing to 
//Show for it. Bad >> umplimented.
public class mouseMovement : MonoBehaviour
{
	private Vector3 _target;
	public Camera Camera;
	public bool FollowMouse;//Debug so we don't have to click everywhere.
	public float playerSpeed = 2.0f;

	public void OnEnable()
	{
		if (Camera == null)
		{
			throw new InvalidOperationException("Camera not set");
		}
	}

	public void Update()
	{
		//Right click to move
		if (FollowMouse || Input.GetMouseButton(1))
		{
			_target = Camera.ScreenToWorldPoint(Input.mousePosition);
			_target.z = 0;
		}

		var delta = playerSpeed*Time.deltaTime;
		delta *= Vector3.Distance(transform.position, _target);

		transform.position = Vector3.MoveTowards(transform.position, _target, delta);
	}
}