using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{

    public GameObject[] targets;
    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");
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
}
