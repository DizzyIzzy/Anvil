using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPanel : MonoBehaviour {

	public GameObject[] dividerList;
	public GameObject[] moveTasks;
	public GameObject[] defenseTasks;
	public GameObject[] miscTasks;

	int dividerIndex = 0;
	int selectorIndex = 0;

	// Use this for initialization
	void Start () {
		dividerList = new GameObject[3];
		moveTasks = new GameObject[3];
		defenseTasks = new GameObject[3];
		miscTasks = new GameObject[3];
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void GetRightInput()
	{
		Debug.Log("Next action");
		dividerIndex++;
		updateTaskUIRight();
	}
	public void GetLeftInput()
	{
		Debug.Log("Previous action");
		dividerIndex--;
		updateTaskUILeft();
	}

	public void updateTaskUIRight()
	{
		int nextTaskDivider = dividerIndex + 1;
		if (nextTaskDivider >= dividerList.Length)
		{
			dividerIndex = 0;
		}
		else
		{
			dividerIndex = nextTaskDivider;
		}
	}

	public void updateTaskUILeft()
	{
		int nextTaskDivider = dividerIndex - 1;
		if (nextTaskDivider < 0)
		{
			dividerIndex = dividerList.Length - 1;
		}
		else
		{
			dividerIndex = nextTaskDivider;
		}
	}

	/*
	public void checkActionSelected()
	{


		switch (dividerIndex)
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
	*/


}
