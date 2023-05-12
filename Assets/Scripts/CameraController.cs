using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera camera;
    public Transform ball;

    public float yOffset;

    private float minY = 9999;

    private void Update()
    {
        Vector3 targetPosition = new Vector3(0, Mathf.Min(ball.position.y + yOffset, minY), -7.36f);

        camera.transform.position = targetPosition;

        if (minY > camera.transform.position.y)
        {
            minY = camera.transform.position.y;
        }
    }
}