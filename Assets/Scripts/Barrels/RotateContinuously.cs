using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateContinuously : MonoBehaviour
{
    [SerializeField] float X;
    [SerializeField] float Y;
    [SerializeField] float Z;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(X, Y, Z) * Time.deltaTime, Space.Self);
    }
}
