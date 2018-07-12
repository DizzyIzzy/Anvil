using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;

public class Defense : AgentTasks{
	private List<AnvilWayPoint> agentWayPoints;
	
	Vector3 currentPosition;
	private List<Vector3> points;

	int currentWP = 0;

	public AnvilWayPoint goToTarget;

	public FieldOfView fov;

	

	private bool dirRight = true;
	public bool inRecon = false;
	private bool fovBool = false;

	float oldRadius;
	float oldAngle;

	public float rotationFreq;



	// Use this for initialization
	void Start()
	{
		points = new List<Vector3>();
		fov = GetComponent<FieldOfView>();
		currentPosition = this.transform.localPosition;

		//This is for the patrol part
		//Only patrols between 10 units in front of it but could change to add a waypoint
		Vector3 patrol1 = currentPosition;
		Vector3 patrol2 = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + 10);
		points.Add(patrol1);
		points.Add(patrol2);


		oldRadius = fov.viewRadius;
		oldAngle = fov.viewAngle;


	}

	// Update is called once per frame
	void LateUpdate()
	{
		//Patrol();
		//Defend();
		Recon();
	}

	//Move between 2 points
	//Could add implementation for more than 2 points
	void Patrol()
	{
		transform.position = Vector3.Lerp(points[0], points[1], Mathf.PingPong(Time.time * speed, 1.0f));
	}

	//This increases the angle and range of the FOV 
	void Defend()
	{

		if(!inRecon)
		{
			fov.viewRadius = oldRadius;
			fov.viewAngle = oldAngle;
		}
		else if (inRecon)
		{
				fov.viewRadius = oldRadius + 10;
				fov.viewAngle  = oldAngle + 60;
		}
		
	}

	//This rotates the agents FOV between 2 angles
	void Recon()
	{
		float angle = Mathf.Sin(Time.time) * rotationFreq; //tweak this to change frequency

		transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
	}

}
