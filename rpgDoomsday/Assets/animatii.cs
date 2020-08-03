﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class animatii : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //for animators
        navMeshAgent = transform.parent.GetComponent<NavMeshAgent>();
        Debug.Log("Parent " + transform.parent.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.velocity.magnitude > 0.001f)
            anim.SetBool("Walk", true);
        else
            anim.SetBool("Walk", false);
    }
}
