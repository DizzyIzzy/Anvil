using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;


public class Tasks : MonoBehaviour {
	public AbstractMap _map;

	//Task Enum
	enum Task{moveNow, idle, defend};
	Task currentTask;

	//Task to display and list of tasks
	public List<string> taskList;
	public string displayTask;

	//The agent we want this task to apply to
	public AnvilAgent agentToOrder;

	public UIControlScript userControl;


	//The point we want the agent to move too


	public float speed;
	public float accuracy;
	public float rotSpeed;



	bool moving = true;

	// Use this for initialization
	void Start () {
		currentTask = Task.idle;
		taskList.Add ("idle");
		taskList.Add("moveNow");
		taskList.Add ("defend");
		
	}

	// Update is called once per frame
	void Update () {
		userControl = GetComponent<UIControlScript>();
		
	}


	public void doTask(string taskName)
	{
		if (taskName == "moveNow") 
		{
		//	agentToOrder.GetComponent<Movement> ().moveToWaypoint (userControl.selectedAgent.navTarget);
		}
	}


	public void moveNow()
	{
		currentTask = Task.moveNow;

	}


	public void checkDisplay()
	{
		if (currentTask == Task.moveNow) {
			displayTask = "moveNow";
		} else if (currentTask == Task.idle) {
			displayTask = "idle";
		} else if (currentTask == Task.defend) {
			displayTask = "defend";
		}
	}



	public void moveToWaypoint(AnvilWayPoint waypoint)
	{

		Debug.Log("Waypoint agent name: " + agentToOrder.agentName);
		Debug.Log("Waypoint Name: " + waypoint.mWayPointName);
		Debug.Log("Lat: " + waypoint.latitude + "Long: " + waypoint.longitude);

		speed = 0.05f;
	

		GameObject goToPoint = new GameObject();

		Vector2d goTo = new Vector2d(waypoint.latitude, waypoint.longitude);
		goToPoint.transform.localPosition = Conversions.GeoToWorldPosition(goTo, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();
		goToPoint.transform.localPosition += new Vector3(0, 10, 0);

		if (moving)
		{
		Vector3 lookAtGoal = new Vector3(goToPoint.transform.localPosition.x, goToPoint.transform.localPosition.y, goToPoint.transform.localPosition.z);
		Vector3 direction = lookAtGoal - agentToOrder.transform.position;

	
		agentToOrder.transform.rotation = Quaternion.Slerp(agentToOrder.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
		agentToOrder.transform.position = Vector3.MoveTowards(agentToOrder.transform.position, goToPoint.transform.position, speed);
		//agentToOrder.transform.position = Vector3.Lerp(agentToOrder.transform.position, goToPoint.transform.position, speed);

		}

		//if (agentToOrder.transform.position == goToPoint.transform.localPosition)
		//{
		//	moving = false;
		//}

	}

}
