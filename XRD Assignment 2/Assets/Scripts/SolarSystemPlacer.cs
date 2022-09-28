using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SolarSystemPlacer : MonoBehaviour
{
    private ARRaycastManager _raycastManager;
    [SerializeField] private GameObject objectToPlace;
    private static List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    private bool instantiated = false;

    private void Start()
    {
        _raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        if(instantiated) return;
        if (Input.touchCount <= 0) return;
        
        var touch = Input.GetTouch(0);
        if(touch.phase != TouchPhase.Began) return;
        if (!_raycastManager.Raycast(touch.position, _hits, TrackableType.PlaneWithinPolygon)) return;
        var hitpose = _hits[0].pose;
        Instantiate(objectToPlace, hitpose.position, hitpose.rotation);
        instantiated = true;
    }
}
