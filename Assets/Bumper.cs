using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] GameObject Grabber;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (Grabber.GetComponent<Grabber>().holded)
        {
            Debug.Log("SHOOT!");
            Grabber.GetComponent<ShootingBall>().Shoot();
            Grabber.GetComponent<Grabber>().holded = false;
        }
        
    }
}
