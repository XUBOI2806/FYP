using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class LegPathRenderer : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private int lineSegments = 60;
    public GameObject leg;
    public string fileName = "positions.csv"; // Name of the output file
    public Vector3[] positions;

    // cooldown
    private float cooldown;
    private float repeatRate = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown < 0)
        {
            ExportPositionsToCSV();
            cooldown = repeatRate;
        }
        cooldown -= Time.deltaTime;
    }

    public void ExportPositionsToCSV()
    {
        string filePath = Path.Combine(Application.dataPath, fileName);
        bool fileExists = File.Exists(filePath);

        using (StreamWriter writer = new StreamWriter(filePath, true))

        {
            // Write the header
            if (!fileExists)
            {
                writer.WriteLine("ObjectName,PositionX,PositionY,PositionZ");
            }

            Vector3 pos = leg.transform.position;
            string line = $"{leg.name},{pos.x},{pos.y},{pos.z}";
            writer.WriteLine(line);
        }

        Debug.Log($"Positions exported to {filePath}");
    }
}
