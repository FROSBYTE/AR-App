using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] Transform main_Camera;
    Vector3 targetAngle = Vector3.zero;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.LookAt(main_Camera);
        targetAngle = transform.localEulerAngles;
        targetAngle.x = 0;
        targetAngle.z = 0;
        transform.localEulerAngles = targetAngle;
    }
}
