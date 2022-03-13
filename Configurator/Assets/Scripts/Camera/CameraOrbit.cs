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
    
    private bool farEnough;

    private void Update()
    {
        CameraControl();
    }
 
    private void CameraControl()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log(transform.eulerAngles);
            //clmap euler angles and use them in roatte around

            /*transform.RotateAround(target.transform.position, Vector3.up, Input.GetAxisRaw("Mouse X") * Time.deltaTime * moveSpeed);

            Vector3 curRotation = transform.rotation.eulerAngles;
            float clampedX = Mathf.Clamp(curRotation.x, minAngle, maxAngle);
            Vector3 clampedRotation = new Vector3(clampedX, curRotation.y, curRotation.z);
            Debug.Log(clampedX);
            transform.eulerAngles = clampedRotation;
            
            transform.RotateAround(target.transform.position, transform.right, -((Input.GetAxisRaw("Mouse Y") * Time.deltaTime) * moveSpeed));*/

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

    /*public void UnZoomCamera()
    {
        //Změnit to na pozici haha
        if (!farEnough)
        {
            Camera.Translate(0f, 0f, -10 * Time.deltaTime * zoomSpeed, Space.Self);
        }
    }*/
}
