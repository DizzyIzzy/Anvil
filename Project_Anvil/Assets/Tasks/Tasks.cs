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
	//public Movement movementTasks;

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
		if (taskName == "Task: moveNow") 
		{
			//agentToOrder.moveScript.moveNow = true;
			//agentToOrder.GetComponent<Movement>().goToTarget = true;
			//movementTasks = agentToOrder.GetComponent<Movement>();
			//movementTasks.
			agentToOrder.GetComponent<Movement>().goToTarget = agentToOrder.navTarget;
			agentToOrder.GetComponent<Movement>().moveNow = true;
			//movementTasks.moveNow = true;
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


}
