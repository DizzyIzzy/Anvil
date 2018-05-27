using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterPanelUI : MonoBehaviour {

	private GameObject masterMenuPanel;
	public Text routeDataLabel;
	public Text waypointDataLabel;
	public Text factionDataLabel;
	public Text agentDataLabel;
	public Text taskDataLabel;

	public Text navTargetLabel;

	private Text thisLabel;
	private Text prevLabel;

	private List<Text> allLabels;

	public UserControlScript controlScript;

	private bool selected;
	private bool routeSelected;

	int menuPoint; 

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

		checkMenuPoint ();
		checkSelected();

		if (selected == false) {
			if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
				Debug.Log (menuPoint);
				menuPoint--;
			}
			if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
				Debug.Log (menuPoint);
				menuPoint++;
			}
		}


		if (Input.GetKeyDown (KeyCode.C)) 
		{
			selected = true;
		}
		if (Input.GetKeyDown (KeyCode.B)) 
		{
			selected = false;
		}

		//routeControl ();
		//waypointControl ();
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

		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			controlScript.prevRoute();
		}
		if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) 
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
