using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillMover : MonoBehaviour
{
    public float angularSpeed = 10f;
    float zRotation = 0f;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * angularSpeed * Time.deltaTime, Space.Self);
    }
}
