using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilSystem:MonoBehaviour {
    [SerializeField] private float systemSerial;
    [SerializeField] private bool isRunning;
    [SerializeField] private bool isImmortal;
    [SerializeField] private float damage;
    private List<AnvilSystem> connectedSystemList;

    //private List<Sensor> sensorList;
    //private List<Transceiver> transceiverList;
    
    // future features 
    // List of Passengers (anvilagents)
    // List of subcomponents
	// List of cargo systems
        // Use this for initialization

	void Start () {
        damage = 100;

    }
	
	// Update is called once per frame
	void Update () {

        }
	}

