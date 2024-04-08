using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class targetScript : MonoBehaviour
{
    GameObject target;
    public ScoreManager ScoreManager;

    public GameObject fractured;
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Debug.Log("ball hit the target!");
            //gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
            ScoreManager.IncrementScore();

            Vector3 oldPos = transform.position;
            Instantiate(fractured, oldPos, Quaternion.identity);
            Destroy(gameObject);

            StartCoroutine(DestroyFracturedObjectAfterDelay(fractured, 1));
        }
    }


    private IEnumerator DestroyFracturedObjectAfterDelay(GameObject obj, float delay)
    {
        Debug.Log("adfasdf");
        yield return new WaitForSeconds(delay);


        Destroy(obj);
    }
}
