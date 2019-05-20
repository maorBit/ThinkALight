using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 RotateDir;
    [SerializeField] private float speed;


    void Update()
    {
        transform.Rotate(RotateDir, Space.Self);
        
    }
}
