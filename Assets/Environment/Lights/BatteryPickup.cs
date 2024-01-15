using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] private float restoreAngle;
    [SerializeField] private float restoreIntensity;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            var flashlight = other.GetComponentInChildren<FlashLightSystem>();
            flashlight.RestoreLightAngle(restoreAngle);
            flashlight.RestoreLightIntensity(restoreIntensity);
            Destroy(gameObject);
        }
    }
}
