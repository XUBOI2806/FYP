using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservationPlayerMovement : PlayerMovement
{
    public GameObject LaceKickingTimelineController; // Reference to the LaceKickingTimelineController GameObject

    public GameObject[] trackers;
    
    protected override void handleShoot()
    {
        // Check if the side kick button is pressed
        if (sideKickPressed)
        {
            // Enable side kicking on the RightShoe's KickBall component
            RightShoe.GetComponent<KickBall>().enableSideKicking();
            // Set the isSideKicking animation parameter to true
            animator.SetBool(isSideKickingHash, true);
        }

        // Check if the side kick button is not pressed
        if (!sideKickPressed)
        {
            // Disable side kicking on the RightShoe's KickBall component
            RightShoe.GetComponent<KickBall>().disableSideKicking();
            // Set the isSideKicking animation parameter to false
            animator.SetBool(isSideKickingHash, false);
        }

        // Check if the lace kick button is pressed
        if (laceKickPressed)
        {
            // Play the lace kicking timeline
            LaceKickingTimelineController.GetComponent<LaceKickingTimelineScript>().play();
            // Enable lace kicking on the RightShoe's KickBall component
            RightShoe.GetComponent<KickBall>().enableLaceKicking();
            // Set the isLaceKicking animation parameter to true
            animator.SetBool(isLaceKickingHash, true);
        }

        // Check if the lace kick button is not pressed
        if (!laceKickPressed)
        {
            // Disable lace kicking on the RightShoe's KickBall component
            RightShoe.GetComponent<KickBall>().disableLaceKicking();
            // Set the isLaceKicking animation parameter to false
            animator.SetBool(isLaceKickingHash, false);
        }
    }

    void switchTrackerColor()
    {
        foreach (var item in trackers)
        {
            item.GetComponent<SpeedColorChanger>().changeTrackerColor();
        }
    }
}
