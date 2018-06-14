using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenuPanel : MonoBehaviour {
	public GameObject actionMenuPanel;

	public Text routeDataLabel;
	public Text waypointDataLabel;
	public Text factionDataLabel;
	public Text agentDataLabel;
	public Text taskDataLabel;

	private Text thisLabel;
	public List<Text> allLabels;

	private int actionPoint;

	// Use this for initialization
	void Start () {
		allLabels = new List<Text>();
		actionPoint = 0;
		getLabels();
		
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
	}
	public void GetLeftInput()
	{
		Debug.Log("Previous action");
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
