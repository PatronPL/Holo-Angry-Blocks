using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float power = 1;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Projectile";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "MapObject")
        {
            Destroy(gameObject, 3);
        }
        
    }
}
