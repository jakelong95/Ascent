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

        Vector3 mousePos = Input.mousePosition;
        Vector3 parentPos = Camera.main.WorldToScreenPoint(parentObject.transform.position);
        
        mousePos.x = mousePos.x - parentPos.x;
        mousePos.y = mousePos.y - parentPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;
        Vector3 oldPos = transform.position;
        transform.position = parentObject.position;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.position = oldPos;


       // float angle = Mathf.Rad2Deg * Mathf.Atan(Mathf.Abs(Input.mousePosition.y - parentObject.transform.position.y) / Mathf.Abs(Input.mousePosition.x - parentObject.transform.position.y));


        //angle = 10;

        //    Vector3 angleOffset = new Vector3(0, 0, angle);

        //transform.position = parentObject.position;
        //transform.rotation = Quaternion.Euler(0, 0, angle);
        //transform.RotateAround(parentObject.position, new Vector3(0, 0, 1), angle);
       // Debug.Log(angle);
        //transform.Rotate(angleOffset);
       // transform.position = parentObject.position + offset;
        //transform.rotation = new Quaternion(0, 0, 0, 0);
       
       // transform.RotateAround(parentObject.position, angle);
        //   transform.position = parentObject.position +  angleOffset;
	}
}
