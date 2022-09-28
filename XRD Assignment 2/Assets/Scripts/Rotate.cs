using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speedAroundTarget;
    [SerializeField] private float speedAroundItself;

    void Update()
    {
        // rotate around itself
        transform.RotateAround(transform.position, transform.up, speedAroundItself * Time.deltaTime);
        
        transform.RotateAround(target.transform.position, target.transform.up, speedAroundTarget * Time.deltaTime);
    }
}