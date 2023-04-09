using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera FPCamera;
    [SerializeField] private float range = 100f;
    [SerializeField] private float weaponDamage;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private Ammo ammoSlot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (ammoSlot.GetAmmoAmount() > 0)
        {
            PlayMuzzleFlash();
            HandleRaycast();
            ammoSlot.ReduceCurrentAmmo();
        }

    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
    
    private void HandleRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(weaponDamage);
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact,0.1f);
    }
}
