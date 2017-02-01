using UnityEngine;
using System.Collections;

public class CollisionCone : MonoBehaviour {

    public Transform parentObject; //The transform of the thing this is attached to.
    public Vector3 offset;
    public float closeEnoughDegrees = 10;
    public float rotationSpeed = 360f;
    public float distance = 5f;

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
        bool enabled = true;
        float rotated = 0;

        //Vector3 oldPos = transform.position;
        //transform.position = parentObject.position;

        // transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        //transform.position = oldPos;
        //Vector3.RotateTowards(transform.position, new Vector3(0,0,angle), 10,10)


        while(Mathf.Abs(rotated - angle) > closeEnoughDegrees)
        {
            transform.RotateAround(parentObject.position, new Vector3(0, 0, 1),  angle);
            rotated += 5;
        }


        Debug.Log(transform.eulerAngles.z);

        if( (Mathf.Abs(transform.eulerAngles.z - angle) <= closeEnoughDegrees )){
            enabled = false;
        }
        if (enabled)
        {
            transform.RotateAround(parentObject.position, new Vector3(0, 0, 1), transform.eulerAngles.z - angle);
        }

        // float angle = Mathf.Rad2Deg * Mathf.Atan(Mathf.Abs(Input.mousePosition.y - parentObject.transform.position.y) / Mathf.Abs(Input.mousePosition.x - parentObject.transform.position.y));


        //angle = 10;

        //    Vector3 angleOffset = new Vector3(0, 0, angle);

        //transform.position = parentObject.position;
        //transform.rotation = Quaternion.Euler(0, 0, angle);
        // transform.RotateAround(parentObject.position, new Vector3(0, 0, 1), angle);
        // Debug.Log(angle);
        //transform.Rotate(angleOffset);
        // transform.position = parentObject.position + offset;
        //transform.rotation = new Quaternion(0, 0, 0, 0);

        // transform.RotateAround(parentObject.position, angle);
        //   transform.position = parentObject.position +  angleOffset;
    }
}
