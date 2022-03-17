using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] GameObject target;

    [Header("Speed")] [SerializeField] float moveSpeed = 300f;
    [SerializeField] float zoomSpeed = 100f;

    [Header("Zoom")] [SerializeField] float minDistance = 2f;
    [SerializeField] float maxDistance = 5f;

    [Header("Clamp")] [SerializeField] float minAngle = 2f;
    [SerializeField] float maxAngle = 80f;

    [Header("Objects")] [SerializeField] Transform cameraRig;
    [SerializeField] Transform camera;

    [SerializeField] private float rotationX;
    [SerializeField] private float rotationY;
    [SerializeField] private float secRotationY;
    private bool isStopping;
    public Rigidbody rb;
    private bool copiedRotation = false;

    private void Update()
    {
        CameraControl();

        if (Input.GetMouseButtonUp(0))
        {
            isStopping = true;
        }

        if (isStopping)
        {
            //Rotace pokračuje
            //transform.rotation = (Quaternion.RotateTowards(transform.rotation, rb.inertiaTensorRotation = Quaternion.Euler(rotationX, rotationY, 0) * Quaternion.Euler(rotationX, rotationY, 0), 10f));
            //transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * Quaternion.Euler(rotationX, rotationY, 0), Time.deltaTime);

            //transform.rotation = (Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotationX, rotationY, 0) * Quaternion.Euler(rotationX, rotationY, 0), Time.deltaTime));
            //rb.MoveRotation(Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotationX, rotationY, 0) * Quaternion.Euler(rotationX, rotationY, 0), Time.deltaTime));
            //transform.rotation = Quaternion.Euler(rotationX,rotationY,0);
            /*if (rotationX >= 0)
            {
                rotationX -= 0.5f;
            }

            if (rotationY >= 0)
            {
                rotationY -= 0.5f;
            }*/
            if (secRotationY > rotationY)
            {
                for (int i = 0; i < 20; i += 1)
                {
                    if (Input.GetMouseButton(0))
                    {
                        Debug.Log("hm");
                        DOTween.Pause(this);
                        isStopping = false;
                        copiedRotation = false;
                        i += 100;
                        break;
                    }
                    rotationY -= 5;
                    transform.DORotate(new Vector3(rotationX, rotationY, 0), 1f);
                    //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotationX, rotationY, 0), 1f);
                }
                

                isStopping = false;
                copiedRotation = false;
            }
            else if (secRotationY < rotationY)
            {
                for (int i = 0; i < 20; i += 1)
                {
                    if (Input.GetMouseButton(0))
                    {
                        DOTween.Pause(this);
                        Debug.Log("hm");
                        isStopping = false;
                        copiedRotation = false;
                        i += 100;
                        return;
                    }
                    rotationY += 5;
                    transform.DORotate(new Vector3(rotationX, rotationY, 0), 1f);
                    //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotationX, rotationY, 0), 1f);
                }

                isStopping = false;
                copiedRotation = false;
            }
            //transform.rotation = Quaternion.Euler(rotationX,rotationY,0);
        }
    }

    private void CameraControl()
    {
        if (Input.GetMouseButton(0))
        {
            if (copiedRotation == false)
            {
                copiedRotation = true;
                secRotationY = rotationY;
            }

            isStopping = false;
            float movementX = Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;
            float movementY = Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime;

            rotationY += movementX;
            rotationX -= movementY;

            rotationX = Mathf.Clamp(rotationX, minAngle, maxAngle);

            /*rb.inertiaTensorRotation = Quaternion.Euler(rotationX, rotationY, 0);
            Debug.Log(rb.inertiaTensorRotation); */
            //rb.MoveRotation(Quaternion.Euler(rotationX, rotationY, 0));
            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
            //rb.AddTorque(new Vector3(rotationX,rotationY,0));
            //rb.MoveRotation(Quaternion.Euler(rotationX,rotationY,0));
            //transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotationX, rotationY, 0), Time.deltaTime * moveSpeed);
        }
        ZoomCamera();
    }

    private void OnMouseUp()
    {
        //isRotating = false;
        isStopping = true;
    }

    private void ZoomCamera()
    {
        float mw = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * 100 * Time.deltaTime;
        if (Vector3.Distance(camera.position, target.transform.position) <= minDistance &&
            Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            return;
        }

        if (Vector3.Distance(camera.position, target.transform.position) >= maxDistance &&
            Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            return;
        }

        camera.Translate(0f, 0f, (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * zoomSpeed, Space.Self);
    }
}