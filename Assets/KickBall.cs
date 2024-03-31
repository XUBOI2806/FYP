using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBall : MonoBehaviour
{
    public GameObject shoe;
    private Vector3 velocity;
    private Vector3 previous;
    private bool isLaceKicking;
    private bool isSideKicking;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isLaceKicking && !isSideKicking)
        {
            shoe.GetComponent<Collider>().enabled = false;
        }
        else
        {
            shoe.GetComponent<Collider>().enabled = true;
        }
        velocity = ((transform.position - previous)) / Time.deltaTime;
        previous = transform.position;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Debug.Log("Ball Detected");
            if(isLaceKicking)
            {
                Debug.Log("Lace Kick");
                collision.gameObject.GetComponent<Rigidbody>().AddForce(velocity.x * 50, velocity.magnitude * 50, velocity.z * 50);
            }
            if(isSideKicking)
            {
                Debug.Log("Side Kick");
                collision.gameObject.GetComponent<Rigidbody>().AddForce(velocity.x * 50, 0, velocity.z * 50);
            }
        }
    }


    public void enableSideKicking()
    {
        isSideKicking = true;
    }

    public void enableLaceKicking()
    {
        isLaceKicking = true;
    }

    public void disableSideKicking()
    {
        isSideKicking=false;
    }

    public void disableLaceKicking()
    {
        isLaceKicking=false;
    }

}
