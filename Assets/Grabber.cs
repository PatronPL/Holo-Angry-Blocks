using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    [SerializeField] GameObject Axis;
    [SerializeField] GameObject ForHingeJoint;
    bool rotate = false;
    public bool holded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            ForHingeJoint.GetComponent<HingeJoint>().useSpring = false;
            RotationUpdate();
        }
    }

    public void RotateOn()
    {
        rotate = true;
    }

    public void RotateOff()
    {
        rotate = !rotate;
        if (!rotate)
        {
            ForHingeJoint.GetComponent<HingeJoint>().useSpring = true;
        }
    }

    public void RotationUpdate()
    {
        Vector3 targetDirection = Axis.transform.position - transform.position;
        Vector3 lookRotation = Vector3.RotateTowards(transform.forward, targetDirection, 100, 0);
        transform.rotation = Quaternion.LookRotation(lookRotation);
    }

    public void StopHold()
    {
        holded = true;
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }
    public void ResetHold()
    {
        holded = false;
        gameObject.GetComponent<SphereCollider>().enabled = true;
    }
}
