using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaneManager : MonoBehaviour
{
    [Header("AR Foundation")]
    [SerializeField] GameObject placementIndicator;
    [SerializeField] ARPlaneManager _arPlaneManager;
    [SerializeField] ARRaycastManager aRRaycastManager;
    [SerializeField] Camera mainARCamera;

    private Pose PlacementPose;

    public static bool placementPoseIsValid;
    public static bool isDetected = true;

    void Update()
    {
        if (isDetected)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
        }
    }

    void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
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

}
