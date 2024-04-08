using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour
{
    GameObject target;
    public ScoreManager ScoreManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball")
        {
            Debug.Log("ball hit the target!");
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
            ScoreManager.IncrementScore();
        }
    }

}
