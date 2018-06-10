using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {

	string vehicleID;
	int vehicleLicense;
	Color color; 
	int vehicleHealth;

    AnvilAgent driver;
	List<AnvilAgent> passengers = new List<AnvilAgent>();

	int fuel;
	int damage;
	int speed;
	int direction;

	AnvilWayPoint location;

	AudioSource engineSound;
	bool engineOn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
	public void addPassenger(AnvilAgent passenger)
	{
		passengers.Add (passenger);
	}





}
