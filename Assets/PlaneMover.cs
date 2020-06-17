using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMover : MonoBehaviour
{
    [SerializeField] GameObject Catapult;
    [SerializeField] GameObject Playground;
    destroyable[] objects;
    bool front = false;
    // Start is called before the first frame update
    void Start()
    {
        RefreshDestroyers();
    }

    // Update is called once per frame
    void Update()
    {
        if (front)
        {
            // look at camera...
            transform.LookAt(Catapult.transform.position, Vector3.up);
            // then lock rotation to Y axis only...
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        }
    }

    public void RefreshDestroyers()
    {
        objects = gameObject.GetComponentsInChildren<destroyable>();
    }

    public void FrontingON()
    {
        front = true;
        foreach(destroyable destroy in objects)
        {
            destroy.Freeze();
        }
    }
    public void FrontingOFF()
    {
        front = false;
        foreach (destroyable destroy in objects)
        {
            destroy.Unfreeze();
        }
    }

}
