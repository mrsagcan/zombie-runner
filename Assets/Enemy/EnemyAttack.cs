using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage = 40f;
    private PlayerHealth target;
    
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void OnDamageTaken()
    {
        Debug.Log(name + "I know that you're attacking me too.");
    }
    
    public void AttackHitEvent()
    {
        if(target == null) return;
        target.TakeDamage(damage);
    }
}
