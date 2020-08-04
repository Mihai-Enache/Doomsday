using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using UnityEngine;

public class MeleeHandler : MonoBehaviour
{
    [SerializeField] private AggressiveMob parentScript;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!parentScript.isAttacking) return;
        other.GetComponent<Hero>().TakeDamage(parentScript.getDamage());
    }
}
