using UnityEngine;

public class SpeedColorChanger : MonoBehaviour
{
    public Color minSpeedColor = Color.white; // Color for no speed
    public Color maxSpeedColor = Color.blue; // Color for maximum speed
    public float maxSpeed = 25f; // The speed at which the color will be maxSpeedColor
    public int smoothingFactor = 3; // Number of frames to average the speed over

    private Renderer objRenderer;
    private Vector3 lastPosition;
    private float[] speedSamples;
    private int sampleIndex;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        lastPosition = transform.position;
        speedSamples = new float[smoothingFactor];
        sampleIndex = 0;
    }

    void FixedUpdate()
    {
        // Calculate speed
        float currentSpeed = Vector3.Distance(transform.position, lastPosition) / Time.fixedDeltaTime;
        lastPosition = transform.position;

        // Store the current speed sample
        speedSamples[sampleIndex] = currentSpeed;
        sampleIndex = (sampleIndex + 1) % smoothingFactor;

        // Calculate the average speed
        float averageSpeed = 0f;
        for (int i = 0; i < smoothingFactor; i++)
        {
            averageSpeed += speedSamples[i];
        }
        averageSpeed /= smoothingFactor;

        // Clamp speed to maxSpeed
        float clampedSpeed = Mathf.Clamp(averageSpeed, 0, maxSpeed);

        // Calculate color based on speed
        float t = clampedSpeed / maxSpeed;
        Color currentColor = Color.Lerp(minSpeedColor, maxSpeedColor, t);

        // Apply color to the renderer
        objRenderer.material.color = currentColor;
    }
    
}
