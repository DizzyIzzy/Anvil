using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilVehicle : MonoBehaviour {

	string vehicleID;
	int vehicleLicense;
	Color color; 
	int vehicleHealth;

    GameObject driver;
	public List<GameObject> passengers = new List<GameObject>();

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
    
	public void addPassenger(GameObject passenger)
	{
		if (!passengers.Contains(passenger))
		{
			if (passengers.Count == 0)
			{
				driver = passenger;
			}
			else
			{
				passengers.Add(passenger);
			}
		}
	}





}
