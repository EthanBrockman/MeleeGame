using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by Calvin
public class ScreenshotCapture : MonoBehaviour
{
    // Define the name of the screenshot file
    public string screenshotFileName = "Screenshot";

    void Update()
    {
        // Check for the key press (e.g., "P" key to take a screenshot)
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Get the current time to append to the filename for uniqueness
            string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string fileName = screenshotFileName + "_" + timestamp + ".png";

            // Capture and save the screenshot
            ScreenCapture.CaptureScreenshot(fileName);

            // Log a message to confirm screenshot
            Debug.Log("Screenshot saved: " + fileName);
        }
    }
}



