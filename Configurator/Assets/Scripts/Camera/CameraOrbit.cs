using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] GameObject target;
 
    [Header("Speed")]
    [SerializeField] float moveSpeed = 300f;
    [SerializeField] float zoomSpeed = 100f;
 
    [Header("Zoom")]
    [SerializeField] float minDistance = 2f;
    [SerializeField] float maxDistance = 5f;
    
    [Header("Clamp")]
    [SerializeField] float minAngle = 2f;
    [SerializeField] float maxAngle = 80f;
    
    [Header("Objects")]
    [SerializeField] Transform CameraRig;
    [SerializeField] Transform Camera;
    
    private float rotationX;
    private float rotationY;
    

    private void Update()
    {
        CameraControl();
    }
 
    private void CameraControl()
    {
        if (Input.GetMouseButton(0))
        {
            float movementX = Input.GetAxis("Mouse X") * moveSpeed * 10 * Time.deltaTime;
            float movementY = Input.GetAxis("Mouse Y") * moveSpeed * 10 * Time.deltaTime;

            rotationY -= movementX;
            rotationX -= movementY;

            rotationX = Mathf.Clamp(rotationX, minAngle, maxAngle);
        
            transform.rotation = Quaternion.Euler(rotationX,rotationY,0);
        }

        ZoomCamera();
    }
 
    private void ZoomCamera()
    {
        float mw = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * 100 * Time.deltaTime;
        if (Vector3.Distance(Camera.position, target.transform.position) <= minDistance &&
            Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            return;
        }

        if (Vector3.Distance(Camera.position, target.transform.position) >= maxDistance &&
            Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            return;
        }
        Camera.Translate(0f, 0f, (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * zoomSpeed, Space.Self);
    }
}
