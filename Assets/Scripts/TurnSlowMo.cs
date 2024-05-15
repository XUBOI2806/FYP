using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSlowMo : MonoBehaviour
{
    // Start is called before the first frame update
    private float currentTimeScale = 0.05f;
    void Start()
    {
        Time.timeScale = currentTimeScale;
        Time.fixedDeltaTime = currentTimeScale * 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
