using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backCollision : MonoBehaviour
{
    public ParticleSystem fireworks;
    // Start is called before the first frame update
    void Start()
    {
        fireworks.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ball")
        {
            Debug.Log("ballentered");
            fireworks.Play();
        }
    }
}
