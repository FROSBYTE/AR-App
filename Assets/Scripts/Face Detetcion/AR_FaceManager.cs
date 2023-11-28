using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AR_FaceManager : MonoBehaviour
{
    private float lastTapTime;
    public float doubleTapTimeThreshold = 0.5f;

    private void DoubleTap()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if it's a tap
            if (touch.phase == TouchPhase.Began)
            {
                // Check for double tap
                if (Time.time - lastTapTime < doubleTapTimeThreshold)
                {
                    //PlaceObject();
                    // Double tap detected
                    Debug.Log("Double Tap!");
                }

                // Update last tap time
                lastTapTime = Time.time;
            }
        }
        // Check for mouse input
        else if (Input.GetMouseButtonDown(0))
        {
            // Check for double tap
            if (Time.time - lastTapTime < doubleTapTimeThreshold)
            {
                //PlaceObject();
                // Double tap detected
                Debug.Log("Double Tap!");
            }

            // Update last tap time
            lastTapTime = Time.time;
        }
    }

}
