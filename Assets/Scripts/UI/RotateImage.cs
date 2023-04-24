using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateImage : MonoBehaviour
{
    [SerializeField] private float xAxis;
    [SerializeField] private float yAxis;
    [SerializeField] private float zAxis;

    void Update()
    {
        transform.Rotate(new Vector3(xAxis, yAxis, zAxis) * Time.deltaTime);
    }
}
