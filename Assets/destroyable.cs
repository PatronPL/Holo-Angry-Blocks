using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyable : MonoBehaviour
{
    public float hp = 10;
    [SerializeField] float affectedMinForce = 1;
    GameObject hitter;
    [Header("Destruction type: 0= target, 1= wood, 2= rock, 3=steel")]
    [SerializeField] byte destructableType = 0;
    public float heavyScaler = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("_OcclusionStrength", 0.0f);
        gameObject.name = "MapObject";
        heavyScaler = 0.3f;
        switch (destructableType)
        {
            case 0:
                gameObject.name = "Target";
                gameObject.tag = "Target";
                hp = 10;
                break;
            case 1:
                hp = 30;
                break;
            case 2:
                hp = 50;
                break;
            case 3:
                hp = 100;
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Projectile" ||collision.collider.name == "MapObject" || collision.collider.name == "Target" || collision.collider.name == "Plane")
        if (collision.relativeVelocity.magnitude > affectedMinForce)
        {
                float hit = 1;
                byte dT = 1;
                if (destructableType == 0)
                    dT = 0;
                if(collision.collider.name != "Plane")
                {
                    hit = collision.relativeVelocity.magnitude * (heavyScaler * collision.gameObject.GetComponent<Rigidbody>().mass) / ((float)dT + 1);
                }
                else
                {
                    hit = collision.relativeVelocity.magnitude * (heavyScaler * 8) / 2;
                }
                
            hp = hp - hit;
            Debug.Log("Affected Force on ID: " + gameObject.name + " Velocity: " + collision.relativeVelocity.magnitude);
                Debug.Log("Hit damage: " + hit);
            //hitter = collision.gameObject;
            if (destructableType != 0)
            {
                float x = 100;
                var material = gameObject.GetComponent<Renderer>();
                switch (destructableType){
                    case 1:
                        x = hp/30;
                        break;
                    case 2:
                        x = hp/50;
                        break;
                    case 3:
                        x = hp/100;
                        break;
                }
                    material.material.SetFloat("_OcclusionStrength", 1-x);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            if(gameObject.tag == "Target")
            {
                gameObject.transform.parent.gameObject.GetComponent<MapManager>().TargetSub();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void Freeze()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    public void Unfreeze()
    {
        StartCoroutine("UnfreezeDelay");
    }
    IEnumerator UnfreezeDelay()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
