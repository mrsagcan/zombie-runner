using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera fpCamera;
    [SerializeField] private float zoomedInFOV = 20f;
    [SerializeField] private float zoomedOutFOV = 45f;
    [SerializeField] private float zoomedInSensitivity = 1;
    [SerializeField] private float zoomedOutSensitivity = 3;
    
    [SerializeField] private FirstPersonController fpController;
    private bool zoomToggle = false;

    private void Start()
    {
        // fpController = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!zoomToggle)
            {
                zoomToggle = true;
                fpCamera.m_Lens.FieldOfView = zoomedInFOV;
                fpController.RotationSpeed = zoomedInSensitivity;
            }
            else
            {
                zoomToggle = false;
                fpCamera.m_Lens.FieldOfView = zoomedOutFOV;
                fpController.RotationSpeed = zoomedOutSensitivity;
            }
        }
    }
}
