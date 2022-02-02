using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject aiObject;
    public Rigidbody aiRigidbody;

    private void Start()
    {
        aiRigidbody = this.GetComponent<Rigidbody>();
    }

    public void UpdateManually()
    {
        
    }

    public void Move()
    {
        
    }
    
}
