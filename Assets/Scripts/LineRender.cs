using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    public string fileName = "positions.csv"; // Name of the CSV file
    public LineRenderer lineRenderer;
    public GameObject leg;

    void Start()
    {
        string filePath = Path.Combine(Application.dataPath, fileName);
        List<Vector3> positions = ReadCSV(filePath);
        
        foreach (Vector3 position in positions)
        {
            Debug.Log("Position " + position.x + " " + position.y + " " + position.z);
        }


        DrawLine(positions.Skip(80).ToArray());

    }

    public List<Vector3> ReadCSV(string filePath)
    {
        List<Vector3> positionDataList = new List<Vector3>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            bool headerSkipped = false;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                // Skip the header line
                if (!headerSkipped)
                {
                    headerSkipped = true;
                    continue;
                }

                string[] values = line.Split(',');

            /*   PositionData data = new PositionData
                {
                    ObjectName = values[0],
                    PositionX = float.Parse(values[1]),
                    PositionY = float.Parse(values[2]),
                    PositionZ = float.Parse(values[3])
                };
            */

                // Add data to position list
                Vector3 data = new Vector3(float.Parse(values[1]), float.Parse(values[2]), float.Parse(values[3]));


                positionDataList.Add(data);
            }
        }

        return positionDataList;
    }

    public void DrawLine(Vector3[] positions)
    {
        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }

}

