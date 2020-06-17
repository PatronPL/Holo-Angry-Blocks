using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    int targetCount = 0;
    [SerializeField] GameObject nextMap;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent.gameObject.GetComponent<PlaneMover>().RefreshDestroyers();
        for(int i =0; i < gameObject.transform.childCount; i++)
        {
            Transform child = gameObject.transform.GetChild(i);
            if(child.gameObject.tag == "Target")
            {
                targetCount++;
            }
        }
        Debug.Log("Targets: " + targetCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TargetSub()
    {
        targetCount--;
        if (targetCount == 0)
        {
            StartCoroutine(MapEndCoroutine());
        }
    }
    IEnumerator MapEndCoroutine()
    {
        yield return new WaitForSeconds(3);
        gameObject.transform.parent.gameObject.GetComponent<MapsEnabler>().NextMapEnabler(nextMap);
        gameObject.SetActive(false);
    }

}
