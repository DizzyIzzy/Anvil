using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UserControlScript : MonoBehaviour {
    // active agent
    public AnvilAgent selectedAgent;
    public List<AnvilAgent> allFactionAgents;
    // active route
    public List<Route> allFactionRoutes;
    public Route selectedRoute;
    public List<WayPoint> activeRouteExecution;
    public List<WayPoint> sensorTargetList;
    // active sensorTarget
    public WayPoint activeSensorTarget;
    // active navTarget
    public WayPoint activeNavTarget;
    // active waypoint 
    public WayPoint activeWayPoint;
    public GameObject faction;

	//active tasks
	public string currentTask;

    public int agentIndex = 0;
    public int routeIndex = 0;
    public int wayPointIndex = 0;
	public int taskIndex = 0;

	//Indeces for tracking
    private int agentCount;
    private int routeListCount;
    private int wayPointListCount;
	private int taskListCount;

	//task object
	public Tasks tasks;

    //for UI output to canvas
    public Text activeAgentLabel;
    public Text activeAgentPosLabel;
    public Text activeAgentDataLabel;
    public Text activeRouteLabel;
    public Text activeWayPointLabel;
    public Text activeWayPointShortLabel;
    public Text activeWayPointPositionLabel;
	public Text activeTaskLabel;

    public GameObject blackBoard;



    // next action as Delegate

    // Use this for initialization
    void Start ()
    {
        //faction hard coded to faction 1 for now
        string factionName = "Faction1";
        blackBoard = GameObject.Find("BlackBoard");


        //reset UI
        if (allFactionRoutes == null)
        {
            activeWayPointLabel.text = "no pts loaded";
            activeRouteLabel.text = "no pts loaded";
        }

        faction = GameObject.Find(factionName);
        allFactionRoutes = blackBoard.GetComponent<BlackBoardScript>().allGameRoutes;
        allFactionAgents = blackBoard.GetComponent<BlackBoardScript>().allGameAgents;



        UpdateAgentUIInfo();
        UpdateRouteUIInfo();
        UpdateWayPointUIInfo();
		UpdateTaskUIInfo ();

        if (allFactionRoutes != null)
        {
            selectedRoute = allFactionRoutes[routeIndex];
            routeListCount = allFactionRoutes.Count;
        }
        agentCount = allFactionAgents.Count;
        
		//blackBoard.GetComponent<BlackBoardScript>().ReadWayPointFile();

		foreach (WayPoint waypoint in allFactionRoutes[routeIndex].routeWayPoints) 
		{
			Debug.Log ("SELECTED " + waypoint.ToSaveString());
		}



    }

    private void UpdateAgentUIInfo()
    {
        selectedAgent = allFactionAgents[agentIndex];
        if (selectedAgent != null)
        {
            activeAgentLabel.text = selectedAgent.mAgentName;
            if (selectedAgent.mLocation != null)
            {
                activeAgentPosLabel.text = selectedAgent.mLocation.ToString();
            }

            //activeAgentPosLabel.text = selectedAgent.mLocation.ToString() + "*\n +" +
            //  ConversionTool.LatLongToUnityVector3D(selectedAgent.mLocation);

            if (selectedAgent.mNavTarget != null)
            {
                if (selectedAgent.mNavTarget.mWayPointName == null)
                {
                    activeAgentDataLabel.text = "- no waypoint set";
                }
                else
                {
                    activeAgentDataLabel.text = selectedAgent.mNavTarget.mWayPointName;
                }
            }

			if (selectedAgent.task != null) 
			{
				if (selectedAgent.task == "")
				{
					activeTaskLabel.text = "Task: Idle";
				}
				else
				{
					activeTaskLabel.text = selectedAgent.task;
				}
			}

        }
    }



		

    public void UpdateRouteUIInfo()
    {
		if (allFactionRoutes != null)
        {
            selectedRoute = allFactionRoutes[routeIndex];
            if (selectedRoute != null)
            {
				//This was previous routeUIinfo
                //activeRouteLabel.text = selectedRoute.mRouteName + "[" + (routeIndex + 1) + "/" + allFactionRoutes.Count + "]";
				activeRouteLabel.text = "Rte: [" + (routeIndex + 1) + "/" + allFactionRoutes.Count + "]";
            }
        }
    }

    public void UpdateWayPointUIInfo()
    {
        if (selectedRoute != null)
        {
            activeWayPoint = selectedRoute.routeWayPoints[wayPointIndex];

			Debug.Log (activeWayPoint.ToSaveString());

			//Old waypointUIinfo
            //activeWayPointLabel.text = "[" + (wayPointIndex + 1) + "/" + selectedRoute.routeWayPoints.Count + "]" + activeWayPoint.mWayPointName;
			activeWayPointLabel.text = "Wpt: " + activeWayPoint.mWayPointName;


            activeWayPointPositionLabel.text = activeWayPoint.LatLonString();
        }
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
				activeTaskLabel.text = "Task: " + currentTask;
			}
		}
	}



    // Update is called once per frame
    void Update () {
	}

    public void NextAgent()
    {
        Debug.Log("NextAgent pressed");
        agentCount = allFactionAgents.Count;
        Debug.Log("NextAgent pressed"+agentCount);
        int nextAgentIndex = agentIndex + 1;
        if (nextAgentIndex >= agentCount)
        {
            agentIndex = 0;
            
        }
        else
        {
            agentIndex = nextAgentIndex;
        }
        UpdateAgentUIInfo();
    }

    public void PrevAgent()
        {
            agentCount = allFactionAgents.Count;
            int prevAgentIndex = agentIndex - 1;
            if (prevAgentIndex < 0)
            {
                agentIndex = agentCount - 1;
            }
            else
            {
                agentIndex = prevAgentIndex;
            }
        UpdateAgentUIInfo();
    }
    public void nextRoute()
    {
		allFactionRoutes = blackBoard.GetComponent<BlackBoardScript>().allGameRoutes;
		allFactionAgents = blackBoard.GetComponent<BlackBoardScript>().allGameAgents;

        routeListCount = allFactionRoutes.Count;
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
		allFactionRoutes = blackBoard.GetComponent<BlackBoardScript>().allGameRoutes;
		allFactionAgents = blackBoard.GetComponent<BlackBoardScript>().allGameAgents;

        routeListCount = allFactionRoutes.Count;
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

	//Gets the next waypoint
    public void nextWayPoint()
    {
		allFactionRoutes = blackBoard.GetComponent<BlackBoardScript>().allGameRoutes;
		allFactionAgents = blackBoard.GetComponent<BlackBoardScript>().allGameAgents;


		int wayPointListCount = selectedRoute.Count();


        int nextWayPointIndex = wayPointIndex + 1;
        if (nextWayPointIndex >= wayPointListCount)
        {
            wayPointIndex = 0;
        }
        else
        {
            wayPointIndex = nextWayPointIndex;
        }

		//activeWayPoint = agentBlackBoard.agentWayPoints[wayPointIndex];

		Debug.Log (activeWayPoint.ToSaveString());



        UpdateWayPointUIInfo();
    }



	//Gets the previous waypoint
    public void prevWayPoint()
    {
		allFactionRoutes = blackBoard.GetComponent<BlackBoardScript>().allGameRoutes;
		allFactionAgents = blackBoard.GetComponent<BlackBoardScript>().allGameAgents;
		
        int wayPointListCount = selectedRoute.Count();
        int prevWayPointIndex = wayPointIndex - 1;
        if (prevWayPointIndex < 0)
        {
            wayPointIndex = wayPointListCount - 1;
        }
        else
        {
            wayPointIndex = prevWayPointIndex;
        }
        UpdateWayPointUIInfo();
    }

    public void PushWayPointToAgent()
    {
        selectedAgent.setNavTarget(activeWayPoint);
        UpdateAgentUIInfo();
    }

	public void PushTaskToAgent()
	{
		selectedAgent.setTask (activeTaskLabel.text);
		UpdateAgentUIInfo ();
	}

	public void prevTask()
	{
		taskListCount = tasks.taskList.Count;
		Debug.Log("NextTask pressed"+taskListCount);
		int nextTaskIndex = taskIndex - 1;
		if (nextTaskIndex < 0)
		{
			taskIndex = tasks.taskList.Count-1;

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
		Debug.Log("NextTask pressed"+taskListCount);
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


}
