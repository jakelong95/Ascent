using UnityEngine;
using System.Collections;

public class CollisionCone : MonoBehaviour
{

    public Transform parentObject; //The transform of the thing this is attached to.
    public Vector3 offset;
    public float rotationAmount = 1.5f;
    public float closeEnoughDegrees = 10;
    public float rotationSpeed = 360f;
    public float distance = 5f;
    public float currentYAngle = 0f;
    public float targAngle = 0f;
    public float rSpeed = 1.0f;
    public float rDistance = 1.0f;
    public float angle;
    public float camrot;

    // Use this for initialization
    void Start()
    {
        offset = new Vector3(0, transform.localScale.y, 0);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 myPo = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = Camera.main.WorldToScreenPoint(Input.mousePosition);
        Vector3 parentPos = Camera.main.WorldToScreenPoint(parentObject.transform.position);
        distance = Vector3.Distance(mousePos, transform.position);
        Vector3 pivot = parentObject.transform.position;

        mousePos.x = mousePos.x - parentPos.x;
        mousePos.y = mousePos.y - parentPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;
        camrot = Camera.main.transform.rotation.z;

      // Vector3 myvec = RotatePointAroundPivot(myPo, parentPos, new Vector3(0, 0, angle));
      // transform.rotation = new Quaternion(myvec.x, myvec.y, myvec.z, 0);
      //



        //bool enabled = true;
        //float rotated = 0;
        //

   //  Vector3 diff = myPo - parentPos;
   //
   //  float currAngle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;
   //
   //  if (Mathf.Abs(currAngle - angle) > closeEnoughDegrees)
   //  {
   //      transform.RotateAround(parentObject.position, new Vector3(0, 0, 1), angle);
   //  }


        // transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, angle), Time.deltaTime);

        // parentObject.rot

        // if (HasMouseMoved())
        //{
        //    targAngle = angle;
        //  spin();
        // }


        //  currentYAngle = Mathf.MoveTowardsAngle(currentYAngle, targetYAngle, rotationSpeed * Time.deltaTime);
        //
        //  transform.position = new Vector3(
        //       pivot.x + Mathf.Sin(currentYAngle * Mathf.Deg2Rad) * distance,
        //       transform.position.z,
        //       pivot.z + Mathf.Cos(currentYAngle * Mathf.Deg2Rad) * distance
        //   );

        //Vector3 oldPos = transform.position;
        //transform.position = parentObject.position;

        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        //transform.position = oldPos;
        //Vector3.RotateTowards(transform.position, new Vector3(0,0,angle), 10,10)


        //  while(Mathf.Abs(rotated - angle) > closeEnoughDegrees)
        //  {
             transform.RotateAround(parentObject.position, new Vector3(0, 0, 1),  angle);
        //      rotated += 5;
        //  }
        //
        //
        //  Debug.Log(transform.eulerAngles.z);
        //
        //  if( (Mathf.Abs(transform.eulerAngles.z - angle) <= closeEnoughDegrees )){
        //      enabled = false;
        //  }
        //  if (enabled)
        //  {
        //      transform.RotateAround(parentObject.position, new Vector3(0, 0, 1), transform.eulerAngles.z - angle);
        //  }
        //
        //  // float angle = Mathf.Rad2Deg * Mathf.Atan(Mathf.Abs(Input.mousePosition.y - parentObject.transform.position.y) / Mathf.Abs(Input.mousePosition.x - parentObject.transform.position.y));
        //
        //
        //  //angle = 10;

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

    void spin()
    {
        float step = rSpeed * Time.deltaTime;
        float orbitCircumfrance = 2F * rDistance * Mathf.PI;
        float distanceDegrees = (rSpeed / orbitCircumfrance) * 360;
        float distanceRadians = (rSpeed / orbitCircumfrance) * 2 * Mathf.PI;

        if (targAngle > 0)
        {
            transform.RotateAround(parentObject.transform.position, Vector3.forward, -rotationAmount);
            targAngle -= rotationAmount;
        }
        else if (targAngle < 0)
        {
            transform.RotateAround(parentObject.transform.position, Vector3.forward, rotationAmount);
            targAngle += rotationAmount;
        }
    }

    bool HasMouseMoved()
    {
        return (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0);
    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        return Quaternion.Euler(angles) * (point - pivot) + pivot;
    }
}