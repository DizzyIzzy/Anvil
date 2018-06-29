 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;

public class Movement : MonoBehaviour {

	public AbstractMap _map;
	public Tasks tasks;

	private List<AnvilWayPoint> agentWayPoints;
	private List<GameObject>points;

	int currentWP = 0;

	public float speed;
	public float accuracy;
	public float rotSpeed;

	public bool moveNow;

	GameObject goToPoint;

	public AnvilAgent agentToOrder;


	public AnvilWayPoint goToTarget;

	// Use this for initialization
	void Start () {
		points = new List<GameObject> ();
		//Invoke("addPoints", 1);

		moveNow = false;
		goToPoint = new GameObject ();
		tasks = GameObject.Find("UIController").GetComponent<Tasks>();
		_map = GameObject.Find("Map").GetComponent<AbstractMap>();

	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		

		if (moveNow)
		{
			executeMoveNow(goToTarget);
		}



	}

    void addPoints()
    {
        Vector2d latLong = new Vector2d(33.951948, -118.402236);
        Vector2d latLong1 = new Vector2d(33.949028, -118.431064);
        Vector2d latLong2 = new Vector2d(33.936320, -118.426153);
        Vector2d latLong3 = new Vector2d(33.940991, -118.383353);
        Vector2d latLong4 = new Vector2d(33.931410, -118.422255);

        GameObject go1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go1.transform.localPosition = Conversions.GeoToWorldPosition(latLong1, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();
        go1.transform.localPosition += new Vector3(0, 8, 0);

        GameObject go2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go2.transform.localPosition = Conversions.GeoToWorldPosition(latLong2, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();
        go2.transform.localPosition += new Vector3(0, 8, 0);

        GameObject go3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go3.transform.localPosition = Conversions.GeoToWorldPosition(latLong3, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();
        go3.transform.localPosition += new Vector3(0, 8, 0);

        GameObject go4 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go4.transform.localPosition = Conversions.GeoToWorldPosition(latLong4, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();
        go4.transform.localPosition += new Vector3(0, 8, 0);

        points.Add(go1);
        points.Add(go2);
        points.Add(go3);
        points.Add(go4);
    }

   
	public void executeRoute()
	{
		//This can be used for going between waypoints in a route
		/*
		Vector3 lookAtGoal = new Vector3 (points [currentWP].transform.localPosition.x, points [currentWP].transform.localPosition.y, points [currentWP].transform.localPosition.z);

		Vector3 direction = lookAtGoal - this.transform.position;

		this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), Time.deltaTime * rotSpeed);

		if (direction.magnitude < accuracy) 
		{
			currentWP++;
			if (currentWP >= points.Count) 
			{
				currentWP = 0;
			}

		}

		this.transform.Translate (0, 0, speed * Time.deltaTime);
		*/
	}



	public void executeMoveNow(AnvilWayPoint waypoint)
	{

		speed = 0.05f;

		Vector2d goTo = new Vector2d(waypoint.latitude, waypoint.longitude);
		goToPoint.transform.localPosition = Conversions.GeoToWorldPosition(goTo, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();
		goToPoint.transform.localPosition += new Vector3(0, 10, 0);

		Vector3 lookAtGoal = new Vector3(goToPoint.transform.localPosition.x, goToPoint.transform.localPosition.y, goToPoint.transform.localPosition.z);
		Vector3 direction = lookAtGoal - this.transform.position;


		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
		this.transform.position = Vector3.MoveTowards(this.transform.position, goToPoint.transform.position, speed);


		if (this.transform.position == goToPoint.transform.localPosition)
		{
			moveNow = false;
		}

	}

	public void idle()
	{
		moveNow = false;
	}



}
