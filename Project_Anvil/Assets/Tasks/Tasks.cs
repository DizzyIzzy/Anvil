using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour {


	enum Task{moveNow, idle, defend};

	Task currentTask;

	public string displayTask;

	public List<string> taskList;

	public AnvilAgent agentToOrder;

	public UserControlScript userControl;

	// Use this for initialization
	void Start () {
		currentTask = Task.idle;
		taskList.Add ("idle");
		taskList.Add("moveNow");
		taskList.Add ("defend");
	}

	// Update is called once per frame
	void Update () {
		userControl = GetComponent<UserControlScript>();
	}


	public void doTask(string taskName)
	{
		if (taskName == "moveNow") 
		{
			agentToOrder.GetComponent<Movement> ().moveToWaypoint (userControl.selectedAgent.mNavTarget);
		}
	}


	public void moveNow()
	{
		currentTask = Task.moveNow;
		//checkDisplay;

	
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
