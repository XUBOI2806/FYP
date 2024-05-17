using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f; // Smoothing factor

    private Vector3 desiredPosition;
    private Vector3 smoothedPosition;

    void LateUpdate()
    {
        // Calculate the desired position with the offset
        desiredPosition = player.position + offset;

        // Smoothly interpolate between the current position and the desired position
        smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Optionally, maintain the original y position to avoid vertical jittering
        // smoothedPosition.y = transform.position.y;

        // Update the camera position
        transform.position = smoothedPosition;
    }
}