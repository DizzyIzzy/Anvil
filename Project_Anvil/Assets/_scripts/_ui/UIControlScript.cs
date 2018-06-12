using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map;


public class UIControlScript : MonoBehaviour {
    private BasicMap MyMap;
    // active agent
    public AnvilAgent selectedAgent;
    public List<AnvilAgent> allFactionAgents;
    // active route
    public List<AnvilRoute> allFactionRoutes;
    public AnvilRoute selectedRoute;
    public List<AnvilWayPoint> activeRouteExecution;
    public List<AnvilWayPoint> sensorTargetList;
    // active sensorTarget
    public AnvilWayPoint activeSensorTarget;
    // active navTarget
    public AnvilWayPoint activeNavTarget;
    // active waypoint 
    public AnvilWayPoint activeWayPoint;
    public GameObject faction;

	//active tasks
	public string currentTask;

    public int agentIndex = 0;
    public int routeIndex = 0;
    public int wayPointIndex = 0;
	public int taskIndex = 0;

	//Indices for tracking
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

    public Texture agentHighlight;
    public Texture WayPointHighlight;

    public MasterBlackBoard blackBoard;
    public Vector3 activeWayPointWorldPoint;

    // next action as Delegate
    private void Awake()
    {
        blackBoard = GameObject.Find("GameController").GetComponent<MasterBlackBoard>();
    }
    // Use this for initialization
    void Start ()
    {
        //faction hard coded to faction 1 for now
        string factionName = "Faction1";

        MyMap = BasicMap.FindObjectOfType<BasicMap>();
        //reset UI
        if (allFactionRoutes == null)
        {
            activeWayPointLabel.text = "no pts loaded";
            activeRouteLabel.text = "no pts loaded";
        }

        faction = GameObject.Find(factionName);
        allFactionRoutes = blackBoard.GetComponent<MasterBlackBoard>().allGameRoutes;
        allFactionAgents = blackBoard.GetComponent<MasterBlackBoard>().allGameAgents;
        
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

		foreach (AnvilWayPoint waypoint in allFactionRoutes[routeIndex].routeWayPoints) 
		{
			Debug.Log ("SELECTED " + waypoint.ToSaveString());
		}
    }

    private void UpdateAgentUIInfo()
    {
        selectedAgent = allFactionAgents[agentIndex];
        blackBoard.setActiveAgent(selectedAgent);
        if (selectedAgent != null)
        {
            activeAgentLabel.text = selectedAgent.agentName;
            if (selectedAgent.locationLatLng != null)
            {
                activeAgentPosLabel.text = selectedAgent.locationLatLng.ToString();
            }

            //activeAgentPosLabel.text = selectedAgent.mLocation.ToString() + "*\n +" +
            //  ConversionTool.LatLongToUnityVector3D(selectedAgent.mLocation);

            if (selectedAgent.navTarget != null)
            {
                if (selectedAgent.navTarget.mWayPointName == null)
                {
                    activeAgentDataLabel.text = "- no waypoint set";
                }
                else
                {
                    activeAgentDataLabel.text = selectedAgent.navTarget.mWayPointName;
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
            activeWayPointWorldPoint = ConversionTool1.WayPointToUnityVector3D2(activeWayPoint);
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

    void Update () {
	}

    public void NextAgent()
    {
        agentCount = allFactionAgents.Count;
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
		allFactionRoutes = blackBoard.GetComponent<MasterBlackBoard>().allGameRoutes;
		allFactionAgents = blackBoard.GetComponent<MasterBlackBoard>().allGameAgents;
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
		allFactionRoutes = blackBoard.GetComponent<MasterBlackBoard>().allGameRoutes;
		allFactionAgents = blackBoard.GetComponent<MasterBlackBoard>().allGameAgents;
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
		allFactionRoutes = blackBoard.GetComponent<MasterBlackBoard>().allGameRoutes;
		allFactionAgents = blackBoard.GetComponent<MasterBlackBoard>().allGameAgents;
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
		allFactionRoutes = blackBoard.GetComponent<MasterBlackBoard>().allGameRoutes;
		allFactionAgents = blackBoard.GetComponent<MasterBlackBoard>().allGameAgents;
		
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


    void OnGUI()
    {
        //Reticle on UI menu selected agent
        int reticleSize = 30;
        int labelHeight = 20;
        if (selectedAgent != null)
            
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(selectedAgent.transform.position);
            GUI.DrawTexture(new Rect(screenPos.x - reticleSize / 2, (Screen.height - screenPos.y - reticleSize / 2), reticleSize, reticleSize), agentHighlight);
            GUI.Label(new Rect(screenPos.x - reticleSize / 2, (Screen.height - screenPos.y + labelHeight), 40, labelHeight), selectedAgent.agentCallsign);
        }
        //Reticle on UI menu selected navTarget
        if (activeWayPoint != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(activeWayPointWorldPoint);
           GUI.DrawTexture(new Rect(screenPos.x - reticleSize/2, (Screen.height - screenPos.y - reticleSize/2), reticleSize, reticleSize), WayPointHighlight);
            GUI.Label(new Rect(screenPos.x - reticleSize / 2, (Screen.height - screenPos.y + labelHeight), 40, labelHeight), activeWayPoint.mWayPointName);
        }
        //Reticle on UI menu selected sensorTarget
        //LineRender from agent to target
    }

}
