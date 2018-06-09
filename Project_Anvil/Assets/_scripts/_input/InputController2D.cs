﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// only works with one model for now
// model must have tag of "Model" for it to respond to the raycasts

public class InputController2D : MonoBehaviour
{
    bool showRoutes = false;
    bool isSelected = false;
    bool displayCheckpointList = false;
    bool displayRouteList = false;
    Plane myPlane;
    Vector3 targetPoint;
    public ModelMove2D ModelMove2D;
    public RouteDisplay routeDisplay;
    public CameraZoom cameraZoom;
    int i = 0;


    // Use this for initialization
    void Start()
    {
        myPlane = new Plane(Vector3.up, transform.position);
        cameraZoom = Camera.main.gameObject.GetComponent<CameraZoom>();
        routeDisplay = GameObject.Find("UIRoute").GetComponent<RouteDisplay>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            { // get the object using a raycast
                if (hit.transform.name == "MapHitDetector")
                { // if statement to move object, assuming it is selected
                    float hitDist;
                    if (myPlane.Raycast(ray, out hitDist))
                    {
                        targetPoint = ray.GetPoint(hitDist);
                      //  Debug.Log(targetPoint);
                        if (ModelMove2D != null)
                        {
                            ModelMove2D.MoveToPoint(targetPoint);
                        }
                    }
                }
                else if (hit.transform.tag == "Model" || hit.transform.tag == "ModelAir")
                { // if statement to select model objects
                    ModelMove2D = hit.transform.gameObject.GetComponent<ModelMove2D>();
                    if (!isSelected)
                    {
                        isSelected = true;
                        string selectedName;
                        Transform theTarget;
                        selectedName = hit.collider.name;
                        theTarget = hit.transform;
                        ModelMove2D.OnSelect(theTarget, selectedName);
                    }
                    else
                    {
                        string selectedName;
                        Transform theTarget;
                        selectedName = hit.collider.name;
                        theTarget = hit.transform;
                        ModelMove2D.OnSelect(theTarget, selectedName);
                        ModelMove2D = null;
                        isSelected = false;
                    }
                }
            }
        }
    }
    

   
}