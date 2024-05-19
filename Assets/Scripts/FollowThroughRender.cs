using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThroughRender : MonoBehaviour
{
    // follow the foot
    public GameObject foot;
    // store the positions of the foot at different intervals
    private List<Vector3> positionlist = new List<Vector3>();
    public LineRenderer line;
    private float cooldown;
    private float repeatRate = 0.025f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //cooldown
        if (cooldown < 0)
        {
            generateLine();
            cooldown = repeatRate;
        }
        cooldown -= Time.deltaTime;

    }


    public void generateLine()
    {
        // add vector3 to position list
        positionlist.Add(foot.transform.position);
        // render line
        line.positionCount = positionlist.Count;
        line.SetPositions(positionlist.ToArray());
    }
}
