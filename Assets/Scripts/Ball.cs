using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    public float jumpForce;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    [Button]
    private void ForceUp()
    {
        rb.AddForce(jumpForce * new Vector3(0, 1, 0), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        ForceUp();
    }

    public float maxVelocity = 0;
    
    private void Update()
    {
        Debug.Log(rb.velocity.y);

        Vector3 currentVelocity = rb.velocity;
        currentVelocity.y = Mathf.Min(currentVelocity.y, 2.805f);
        rb.velocity = currentVelocity;
        
        if (rb.velocity.y > maxVelocity)
        {
            maxVelocity = rb.velocity.y;
        }
    }
}
