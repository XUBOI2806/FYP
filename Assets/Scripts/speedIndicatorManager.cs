using UnityEngine;

public class SpeedIndicatorScript : MonoBehaviour
{

    private float maxSpeed = 50000f;
    public float maxSaturation = 1f;
    public float minSaturation = 0.2f;

    private Renderer renderer;

    public float smoothingFactor = 0.5f;

    private Vector3 previousPosition;
    private float previousTime;
    private Vector3 velocity;

    void Start()
    {
        
        renderer = GetComponent<Renderer>();

        if (renderer == null)
        {
            Debug.LogError("Renderer not found.");
            enabled = false; // Disable the script if essential components are missing
        }
        
        previousPosition = transform.position;
        previousTime = Time.time;
    }

    void Update()
    {
        // Calculate change in position
        Vector3 currentPosition = transform.localPosition;
        Vector3 deltaPosition = currentPosition - previousPosition;

        // Calculate change in time
        float deltaTime = Time.time - previousTime;


        // Calculate smoothed velocity
        velocity = Vector3.Lerp(velocity, deltaPosition / deltaTime, smoothingFactor);

        // Update previous position and time for next frame
        previousPosition = currentPosition;
        previousTime = Time.time;

        Debug.Log(velocity.magnitude);

        
        if (renderer == null)
            return;

        // Calculate relative velocity with respect to the reference object
        
        float speed = transform.localPosition.magnitude / Time.deltaTime;
        Debug.Log(speed);

        // Calculate saturation based on velocity
        float normalizedSpeed = Mathf.Clamp01(speed / maxSpeed);
        float saturation = Mathf.Lerp(minSaturation, maxSaturation, normalizedSpeed);

        // Calculate hue based on speed or any other desired parameter
        float hue = Mathf.Lerp(0.33f, 0.66f, normalizedSpeed); // Example hue range

        // Set the color using HSV
        Color color = Color.HSVToRGB(hue, saturation, 1f);

        // Apply the color to the material
        renderer.material.color = color;
        
    }

}
