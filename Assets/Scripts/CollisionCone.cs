using UnityEngine;
using System.Collections;

public class CollisionCone : MonoBehaviour {

    public Transform parentObject; //The transform of the thing this is attached to.
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = new Vector3(0, transform.localScale.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = parentObject.position + offset;
        transform.rotation = new Quaternion(0, 0, 0, 0);
	}
}
