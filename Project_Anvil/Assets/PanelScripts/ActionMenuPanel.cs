using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenuPanel : MonoBehaviour {
	public GameObject actionMenuPanel;

	//Action menu Labels
	public Text routeDataLabel;
	public Text waypointDataLabel;
	public Text factionDataLabel;
	public Text agentDataLabel;
	public Text taskDataLabel;
	//For highlighting labels
	private Text thisLabel;
	public List<Text> allLabels;

	//Reference to scripts
	public UIControlScript uiControlScript;
	public Tasks tasks;
	public AgentPanel agentPanel;

	//Index for action selector
	private int actionPoint;

	//To handle routes
	public List<AnvilRoute> allUIRoutes;
	public AnvilRoute selectedRoute;
	//To handle waypoints
	public AnvilWayPoint activeWayPoint;

	//Indeces
	int routeIndex = 0;
	int waypointIndex = 0;
	int taskIndex = 0;

	//Stores size of lists
	int routeListCount;
	int taskListCount;

	//Current Task
	string currentTask;

	// Use this for initialization
	void Start () {
		allLabels = new List<Text>();
		actionPoint = 0;
		getLabels();

		allUIRoutes = MasterBlackBoard.allGameRoutes;

		if (allUIRoutes != null)
		{
			selectedRoute = allUIRoutes[routeIndex];
			routeListCount = allUIRoutes.Count;
			
		}

		UpdateRouteUIInfo();
		UpdateWayPointUIInfo();
		UpdateTaskUIInfo();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetUpInput()
	{
		actionPoint--;
		checkActionSelected();
	}

	public void GetDownInput()
	{
		actionPoint++;
		checkActionSelected();
	}

	public void GetRightInput()
	{
		Debug.Log("Next action");
		updateActionUIRight();
	}
	public void GetLeftInput()
	{
		Debug.Log("Previous action");
		updateActionUILeft();
	}

	public void GetCInput()
	{
		Debug.Log("C PRESSED");
		checkCSelection();
		agentPanel.UpdateAgentUIInfo();
	}



	public void getLabels()
	{
		routeDataLabel = GameObject.Find("RouteData").GetComponent<UnityEngine.UI.Text>();
		waypointDataLabel = GameObject.Find("WaypointData").GetComponent<UnityEngine.UI.Text>();
		factionDataLabel = GameObject.Find("FactionData").GetComponent<UnityEngine.UI.Text>();
		agentDataLabel = GameObject.Find("AgentData").GetComponent<UnityEngine.UI.Text>();
		taskDataLabel = GameObject.Find("TaskData").GetComponent<UnityEngine.UI.Text>();

		allLabels.Add(routeDataLabel);
		allLabels.Add(waypointDataLabel);
		allLabels.Add(factionDataLabel);
		allLabels.Add(agentDataLabel);
		allLabels.Add(taskDataLabel);
	}

	public void updateActionUIRight()
	{
		switch (actionPoint)
		{
			case 0:
				nextRoute();
				break;
			case 1:
				nextWayPoint();
				break;
			case 2:
				Debug.Log("Next Faction");
				break;
			case 3:
				Debug.Log("Next Agent");
				break;
			case 4:
				nextTask();

				break;
		}
	}

	public void updateActionUILeft()
	{
		switch (actionPoint)
		{
			case 0:
				prevRoute();
				break;
			case 1:
				prevWayPoint();
				break;
			case 2:
				Debug.Log("Previous Faction");
				break;
			case 3:
				Debug.Log("Previous Agent");
				break;
			case 4:
				prevTask();

				break;
		}
	}



	public void nextRoute()
	{
		allUIRoutes = MasterBlackBoard.allGameRoutes;

		routeListCount = allUIRoutes.Count;
		int nextRouteIndex = routeIndex + 1;
		if (nextRouteIndex >= routeListCount)
		{
			routeIndex = 0;
		}
		else
		{
			routeIndex = nextRouteIndex;
		}
		UpdateRouteUIInfo();
		UpdateWayPointUIInfo();
	}

	public void prevRoute()
	{
		allUIRoutes = MasterBlackBoard.allGameRoutes;
		routeListCount = allUIRoutes.Count;
		int prevRouteIndex = routeIndex - 1;
		if (prevRouteIndex < 0)
		{
			routeIndex = routeListCount - 1;
		}
		else
		{
			routeIndex = prevRouteIndex;
		}
		UpdateRouteUIInfo();
		UpdateWayPointUIInfo();
	}

	public void nextWayPoint()
	{
		int wayPointListCount = selectedRoute.Count();
		int nextWayPointIndex = waypointIndex + 1;
		if (nextWayPointIndex >= wayPointListCount)
		{
			waypointIndex = 0;
		}
		else
		{
			waypointIndex = nextWayPointIndex;
		}
		//activeWayPoint = agentBlackBoard.agentWayPoints[wayPointIndex];
		Debug.Log(activeWayPoint.ToSaveString());
		UpdateWayPointUIInfo();
	}

	public void prevWayPoint()
	{
		allUIRoutes = MasterBlackBoard.allGameRoutes;

		int wayPointListCount = selectedRoute.Count();
		int prevWayPointIndex = waypointIndex - 1;
		if (prevWayPointIndex < 0)
		{
			waypointIndex = wayPointListCount - 1;
		}
		else
		{
			waypointIndex = prevWayPointIndex;
		}
		UpdateWayPointUIInfo();
	}

	public void UpdateRouteUIInfo()
	{
		if (allUIRoutes != null)
		{
			selectedRoute = allUIRoutes[routeIndex];
			if (selectedRoute != null)
			{
				routeDataLabel.text = "Rte: [" + (routeIndex + 1) + "/" + allUIRoutes.Count + "]";
			}
		}
	}


	public void UpdateWayPointUIInfo()
	{
		if (selectedRoute != null)
		{
			activeWayPoint = selectedRoute.routeWayPoints[waypointIndex];
			//activeWayPointWorldPoint = ConversionTool1.WayPointToUnityVector3D2(activeWayPoint);
			waypointDataLabel.text = "Wpt: " + activeWayPoint.mWayPointName;
			//activeWayPointPositionLabel.text = activeWayPoint.LatLonString();
		}
	}


	public void prevTask()
	{
		taskListCount = tasks.taskList.Count;
		Debug.Log("NextTask pressed" + taskListCount);
		int nextTaskIndex = taskIndex - 1;
		if (nextTaskIndex < 0)
		{
			taskIndex = tasks.taskList.Count - 1;

		}
		else
		{
			taskIndex = nextTaskIndex;
		}
		UpdateTaskUIInfo();
	}


	public void nextTask()
	{
		taskListCount = tasks.taskList.Count;
		Debug.Log("NextTask pressed" + taskListCount);
		int nextTaskIndex = taskIndex + 1;
		if (nextTaskIndex >= taskListCount)
		{
			taskIndex = 0;

		}
		else
		{
			taskIndex = nextTaskIndex;
		}
		UpdateTaskUIInfo();
	}



	public void UpdateTaskUIInfo()
	{
		if (tasks.taskList != null)
		{
			if (currentTask != null)
			{
				currentTask = tasks.taskList[taskIndex];
				//This was previous routeUIinfo
				//activeRouteLabel.text = selectedRoute.mRouteName + "[" + (routeIndex + 1) + "/" + allFactionRoutes.Count + "]";
				taskDataLabel.text = "Task: " + currentTask;
			}

			currentTask = tasks.taskList[taskIndex];
			taskDataLabel.text = "Task: " + currentTask;

		}

	}



	public void checkCSelection()
	{
		switch (actionPoint)
		{
			case 0:
				Debug.Log("Set this route to something");
				break;
			case 1:
				agentPanel.selectedAgent.navTarget = activeWayPoint;
				//Debug.Log("Selected Agent: " + agentPanel.selectedAgent.navTarget.mWayPointName);
				//agentPanel.UpdateAgentUIInfo();
				break;
			case 2:
				Debug.Log("Set this faction to something");
				break;
			case 3:
				Debug.Log("Set this agent to something");
				break;
			case 4:
				agentPanel.selectedAgent.task = taskDataLabel.text;
				tasks.agentToOrder = agentPanel.selectedAgent;
				tasks.moveToWaypoint(agentPanel.selectedAgent.navTarget);
				//agentPanel.selectedAgent.GetComponent<Tasks>().moveToWaypoint(agentPanel.selectedAgent.navTarget);

			//	agentPanel.UpdateAgentUIInfo();

				break;
		}
	}

	

	public void checkActionSelected()
	{
		Debug.Log("Before CheckActionPoint: " + actionPoint);
		if (actionPoint >= 5)
		{
			actionPoint = 0;
		}
		else if (actionPoint < 0)
		{
			actionPoint = 4;
		}
		Debug.Log("AFter ActionPoint: " + actionPoint);

		switch (actionPoint)
		{
			case 0:
				thisLabel = routeDataLabel;
				break;
			case 1:
				thisLabel = waypointDataLabel;
				break;
			case 2:
				thisLabel = factionDataLabel;
				break;
			case 3:
				thisLabel = agentDataLabel;
				break;
			case 4:
				thisLabel = taskDataLabel;
				break;
		}

		thisLabel.color = Color.red;

		foreach (Text label in allLabels)
		{
			if (!(thisLabel.Equals(label)))
			{
				label.color = Color.white;
			}
		}
	}



}
