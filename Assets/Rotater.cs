using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] GameObject Capsule;
    [SerializeField] GameObject Base;
    [SerializeField] GameObject ShootingPoint;
    [SerializeField] GameObject Plane;
    bool holded = false;
    bool distance = false;
    // Start is called before the first frame update
    void Start()
    {
        PowerCounter();
    }

    // Update is called once per frame
    void Update()
    {
        if (holded)
        {
            PointTowards();
        }
        if (distance)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            //Distanser();
        }
    }

    public void Holder()
    {
        holded = !holded;
    }
    public void Distancer()
    {
        distance = !distance;
    }

    public void PointTowards()
    {
        Debug.Log("Obracanko");

        //transform.rotation.SetFromToRotation(Capsule.transform.position, transform.position);
        transform.LookAt(Capsule.transform);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y+180, 0);
        
        //transform.rotation = Quaternion.Euler(0, -transform.rotation.y, 0);

        //Vector3 newV3 = new Vector3(-90f, Vector3.RotateTowards(Capsule.transform.position, transform.forward, 100, 0).y, 0f);
        //transform.rotation = Quaternion.LookRotation(newV3);
    }

    public void Distanser()
    {
        Debug.Log(" Distancer!");
        transform.localPosition = new Vector3(0, 0, -0.7f);
        
    }

    public void PowerCounter()
    {
        float power = 120;
        float distance = Vector3.Distance(ShootingPoint.transform.position, Plane.transform.position);
        power = distance * 60;
        Debug.Log("Distance: " + distance + " Counted power: " + power);
        gameObject.GetComponentInChildren<ShootingBall>().powerScaler = power;
    }

}
