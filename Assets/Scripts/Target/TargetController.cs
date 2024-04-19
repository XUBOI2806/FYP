using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float decreaseSizeFactor = 0.9f;
    public float expandSizeFactor = 1.1f;
    public GameObject[] targets;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // randomise function for all targets
    public void randomiseTargets()
    {
        foreach(GameObject target in targets)
        {
            target.transform.localPosition = new Vector3(Random.Range(-3.16f, 3.163f), Random.Range(0.484f, 1.955f), 1.117f);
        }
    }
    public void ShrinkTargets()
    {
        foreach (GameObject target in targets)
        {
            
            // Scale down the target by resizeFactor
            target.transform.localScale *= decreaseSizeFactor;
            Debug.Log("ShrinkTargets()");
            
        }
    }
    public void ExpandTargets()
    {
        foreach (GameObject target in targets)
        {
            
            // Scale down the target by resizeFactor
            target.transform.localScale *= expandSizeFactor;
            Debug.Log("ShrinkTargets()");
            
        }
    }
}
