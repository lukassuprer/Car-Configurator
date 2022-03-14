using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Runtime.InteropServices;

public class FreeLookInput : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    private string XAxisName = "Mouse X";
    private string YAxisName = "Mouse Y";

    private void Start()
    {
        freeLookCamera.m_XAxis.m_InputAxisName = "";
        freeLookCamera.m_YAxis.m_InputAxisName = "";
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        if (Input.GetMouseButton(0))
        {
            freeLookCamera.m_XAxis.m_InputAxisValue = Input.GetAxis(XAxisName);
            freeLookCamera.m_YAxis.m_InputAxisValue = Input.GetAxis(YAxisName);
        }
        else
        {
            freeLookCamera.m_XAxis.m_InputAxisValue = 0;
            freeLookCamera.m_YAxis.m_InputAxisValue = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            freeLookCamera.m_Lens.FieldOfView = 20;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && freeLookCamera.m_Lens.FieldOfView <= 100) // forward
        {
            freeLookCamera.m_Lens.FieldOfView++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && freeLookCamera.m_Lens.FieldOfView >= 2) // backwards
        {
            freeLookCamera.m_Lens.FieldOfView--;
        }
    }
}
