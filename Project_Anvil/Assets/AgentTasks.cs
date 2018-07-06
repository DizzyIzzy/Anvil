using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;


public class AgentTasks : MonoBehaviour {

	public AbstractMap _map;
	public float speed;
	public float accuracy;
	public float rotSpeed;



	void Start () {

	}
	

	void Update () {
		
	}

}

public class Task
{
	public string taskName;
	public int UIindex;
	//public int precondition;
	//public int postcondition;
	public int timeToExecute;
	public List<int> waypoints;
	public int priority;

	public Task(string name, int taskPriority)
	{
		taskName = name;
		priority = taskPriority;
	}

	public void doTask()
	{
		//doTask
	}

}
