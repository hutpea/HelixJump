using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    private Vector3 prevPos = Vector3.zero;
    private Vector3 deltaPos = Vector3.zero;
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            deltaPos = Input.mousePosition - prevPos;
            transform.Rotate(transform.up, - deltaPos.x);
        }
        prevPos = Input.mousePosition;
    }
}
