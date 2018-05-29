using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterPanelUI : MonoBehaviour {

	private GameObject masterMenuPanel;

	//Text Objects
	public Text routeDataLabel;
	public Text waypointDataLabel;
	public Text factionDataLabel;
	public Text agentDataLabel;
	public Text taskDataLabel;
	public Text navTargetLabel;
	private Text thisLabel;
	private List<Text> allLabels;

	public UserControlScript controlScript;
	public PlayerSelect playerSelect;
	public KeyTracker keyTracker;

	public bool selected;
	private bool routeSelected;

	int menuPoint; 
	int startSelect = 0;

	// Use this for initialization
	void Start () {
		selected = false;
		routeSelected = false;
		menuPoint = 0;

		allLabels = new List<Text> ();

		addLabels ();

		masterMenuPanel = GameObject.Find("MasterMenuPanel");

		routeDataLabel.color = Color.red;
		
	}
	
	// Update is called once per frame
	void Update () {

	}
		


	public void masterMenuControl()
	{
		/*
		keyTracker.agentActionSelect = true;
		//masterMenuPanel.gameObject.SetActive(true);
		getInputs ();
		Debug.Log (selected);
		*/
	}

	public void getInputs()
	{
		
			if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
				menuPoint--;
			}
			if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
				menuPoint++;
			}
		

			if (Input.GetKeyDown (KeyCode.C)) {
				if (selected == false) {
					selected = true;
				} else {
					selected = false;
				}
				
			}
		
		/*
		if (Input.GetKeyDown (KeyCode.B)) 
		{
			selected = false;
			playerSelect.selection = false;
			keyTracker.agentActionSelect = true;
		}
	*/

		checkMenuPoint ();
		checkSelected();
	}


	public void checkMenuPoint()
	{
		if (menuPoint > 4 ) {
			menuPoint = 0;
		} 
		else if (menuPoint < 0) {
			menuPoint = 4;
		}
	}

	public void checkSelected()
	{
		switch (menuPoint)
		{
		case 0:
			thisLabel = routeDataLabel;
			if (!selected) 
			{
				routeControl ();
			}
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
			if (!(thisLabel.Equals(label)) ) 
			{
				label.color = Color.white;
			}
		}			
	}

	private void specificCheck(int specificPoint)
	{
		switch (specificPoint)
		{
		case 0:
			thisLabel = routeDataLabel;
			if (selected) 
			{
				routeControl ();
			}
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
			if (!(thisLabel.Equals(label)) ) 
			{
				label.color = Color.white;
			}
		}
	}


	private void addLabels()
	{
		allLabels.Add (routeDataLabel);
		allLabels.Add (waypointDataLabel);
		allLabels.Add (factionDataLabel);
		allLabels.Add (agentDataLabel);
		allLabels.Add (taskDataLabel);
	}



	private void routeControl()
	{
		routeSelected = false;

		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			controlScript.prevRoute();
		}
		else if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			controlScript.nextRoute();
		}

		if (Input.GetKeyDown (KeyCode.C)) 
		{
			routeSelected = true;
		}

		if (controlScript.activeRouteLabel != null) 
		{
			routeDataLabel.text = controlScript.activeRouteLabel.text;
		}

		if (routeSelected) 
		{
			waypointControl();
		}

	}

	private void waypointControl()
	{
		specificCheck (1);

		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			controlScript.prevWayPoint();
		}
		if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			controlScript.nextWayPoint();
		}


		if (controlScript.activeRouteLabel != null) 
		{
			waypointDataLabel.text = controlScript.activeWayPointLabel.text;
		}


		if (Input.GetKeyDown (KeyCode.C)) 
		{
			
			navTargetLabel.text = controlScript.activeWayPointLabel.text;

		}

	}

}
