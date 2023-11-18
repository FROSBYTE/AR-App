using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AR_PlaneManager : MonoBehaviour
{
    public static AR_PlaneManager Instance;

    [Header("AR Foundation")]
    [SerializeField] GameObject placementIndicator;
    [SerializeField] ARPlaneManager _arPlaneManager;
    [SerializeField] ARRaycastManager aRRaycastManager;
    [SerializeField] Camera mainARCamera;
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] GameObject instructionText;

    [Header("UI References")]
    [SerializeField] GameObject grounddetectiom_Button;
    [SerializeField] GameObject walldetection_Button;

    private float lastTapTime;
    public float doubleTapTimeThreshold = 0.5f;

    private Pose PlacementPose;
    private GameObject spawnedObject;

    public static bool placementPoseIsValid;
    public static bool isDetected = true;

    private void Start()
    {
        _arPlaneManager.detectionMode = PlaneDetectionMode.Horizontal;
    }

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (isDetected)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
            DoubleTap();
        }
    }

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
                    PlaceObject();
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
                PlaceObject();
                // Double tap detected
                Debug.Log("Double Tap!");
            }

            // Update last tap time
            lastTapTime = Time.time;
        }
    }

    void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            instructionText.SetActive(true);
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
            instructionText.SetActive(false);
        }
    }


    void UpdatePlacementPose()
    {
        var screenCenter = mainARCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }
    }

    public void PlaceObject()
    {
        // Check if there is an existing spawnedObject
        if (spawnedObject != null)
        {
            instructionText.SetActive(true);
            // Destroy the existing spawnedObject
            Destroy(spawnedObject);
            spawnedObject = null;

            // Check if enough time has passed since the last instantiation
            if (Time.time - lastTapTime <= doubleTapTimeThreshold)
            {
                return; // Exit the function if it's too soon for a new instantiation
            }
        }

        // Instantiate a new objectToSpawn
        spawnedObject = Instantiate(objectToSpawn, PlacementPose.position, PlacementPose.rotation);
        instructionText.SetActive(false);

        // Update last tap time
        lastTapTime = Time.time;
    }
}

