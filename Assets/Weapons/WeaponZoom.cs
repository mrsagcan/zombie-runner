using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera fpCamera;
    [SerializeField] private float zoomedInFOV = 20f;
    [SerializeField] private float zoomedOutFOV = 45f;

    private bool zoomToggle = false;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!zoomToggle)
            {
                zoomToggle = true;
                fpCamera.m_Lens.FieldOfView = zoomedInFOV;
            }
            else
            {
                zoomToggle = false;
                fpCamera.m_Lens.FieldOfView = zoomedOutFOV;
            }
        }
    }
}
