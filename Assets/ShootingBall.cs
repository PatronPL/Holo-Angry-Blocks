using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBall : MonoBehaviour
{
    [SerializeField] GameObject ShootPoint;
    [SerializeField] GameObject Projectile;
    public float powerScaler = 1f;
    float shootPower;
    Vector3 shootV3;
    // 0 / 1.1 // 1.5
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Power counter
    public void PowerCounter()
    {
        //float powerV3 = Vector3.Distance(transform.position, ShootPoint.transform.position);
        shootPower = -powerScaler;
        shootV3 = transform.position - ShootPoint.transform.position;
        shootV3 = shootV3 * shootPower;
        Debug.Log(" Shoot Power: "+shootPower+ " Shoot Vector3: "+shootV3);
    }

    public void Shoot()
    {
        GameObject Bullet = Instantiate(Projectile, ShootPoint.transform.position, Quaternion.identity);
        Bullet.GetComponent<Rigidbody>().AddForce(shootV3,ForceMode.Impulse);
        gameObject.GetComponent<SphereCollider>().enabled = true;
    }
}
