using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {

	string vehicleID;
	int vehidleLicense;
	Color color; 
	int vehicleHealth;

	NPCAgent driver;
	List<NPCAgent> passengers = new List<NPCAgent>();

	int fuel;
	int damage;
	int speed;
	int direction;

	WayPoint location;

	AudioSource engineSound;
	bool engineOn;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void addPassenger(NPCAgent passenger)
	{
		passengers.Add (passenger);
	}





}
