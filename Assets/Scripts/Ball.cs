using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    public float jumpForce;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private float maxY = 0f;
    
    private void Start()
    {
        maxY = GameplayController.Instance.levelController.numberOfStages;
    }

    [Button]
    private void ForceUp()
    {
        rb.AddForce(jumpForce * new Vector3(0, 1, 0), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Destination")
        {
            GameplayController.Instance.gameplayUIController.ToggleGameOverPanel(true, true);
        }
        if(other.gameObject.tag == "Hazard")
        {
            other.gameObject.SetActive(false);
            var particle = Instantiate(GameController.Instance.prefabLoader.redPlatformDestroyEffect);
            particle.transform.position = other.transform.position;
        }
        else
        {
            ForceUp();
        }
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

    private void FixedUpdate()
    {
        if (transform.position.y <= -maxY - 1)
        {
            rb.isKinematic = true;
        }
    }
}
