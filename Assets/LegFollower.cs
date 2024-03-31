using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegFollower : MonoBehaviour
{

    public GameObject leg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = leg.transform.rotation;
        transform.position = leg.transform.position;
    }
}
