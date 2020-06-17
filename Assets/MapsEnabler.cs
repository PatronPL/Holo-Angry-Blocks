using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapsEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextMapEnabler(GameObject nextMap)
    {
        StartCoroutine(NextMapCoroutine(nextMap));
    }

    IEnumerator NextMapCoroutine(GameObject nextMap)
    {
        yield return new WaitForSeconds(2);
        nextMap.SetActive(true);
    }
}
