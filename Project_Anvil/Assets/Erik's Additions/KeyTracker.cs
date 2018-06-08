using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;

public class KeyTracker : MonoBehaviour {

	public AbstractMap _map;

	//This keeps track of what we want to select from main menu
	public int menuPoint = 0;
	public int actionPoint = 0;

	//References to other scripts
	CameraController cameraMove;
	public UserControlScript userControl;
	public BlackBoardScript blackBoard;
	public Tasks taskToDo;

	//This determines which selection we are using
	public bool mainMenuSelect;
	public bool agentMenuSelect;
	public bool agentActionSelect;

	//These are the buttons
    private UnityEngine.UI.Button settingButton;
	private UnityEngine.UI.Button playerButton;
	private UnityEngine.UI.Button waypointButton;
	private UnityEngine.UI.Button mapButton;

	//These hold the GUI panels to turn on or off
	private GameObject mainMenuPanel;
	private GameObject agentPanel;
	private GameObject debugPanel;
	public GameObject actionMenuPanel;
	public GameObject moveAgent;
	public GameObject routePanel;


	//These are the text objects for the menu
	public Text routeDataLabel;
	public Text waypointDataLabel;
	public Text factionDataLabel;
	public Text agentDataLabel;
	public Text taskDataLabel;
	private Text thisLabel;
	private List<Text> allLabels;


	//Booleans
	public bool moving;


	void Start () {
		agentActionSelect = false;
		mainMenuSelect = false;
	    cameraMove = GetComponent(typeof(CameraController)) as CameraController;

		taskToDo = GetComponent<Tasks> ();

		allLabels = new List<Text> ();

		//Assigns all the panels
		getPanels();
		getButtons ();
		addLabels();
		actionMenuPanel.gameObject.SetActive (false);

		moving = false;

	}
	
	// Update is called once per frame
	void Update () {
		checkMenuPoint ();
		checkCameraMove ();

		getInput ();

		checkSelected ();

		//This helps highlight the different main menu options
		switch (menuPoint)
		{
		case 0:
			//Code for setting menu
			break;
		case 1:
			//This is the case for the agent menu
			if(mainMenuSelect==true)
			{
			uiPicker(menuPoint);
			agentMenuSelect = true;
				//If we are already in the agent Menu and now we go into the action menu
				if (agentActionSelect == true) {
					actionMenuPanel.gameObject.SetActive (true);
					//agentPanel.gameObject.SetActive (false);
					checkActionPoint ();
					checkActionSelected ();
				} else {
					actionMenuPanel.gameObject.SetActive (false);
					agentPanel.gameObject.SetActive (true);
				}
			}
			break;
		case 2:
			//Code for waypoint menu
			if(mainMenuSelect==true)
			{
			uiPicker(menuPoint);
			//waypointUI();
			}
			break;
		case 3:
			//Code for camera menu
			//if (cameraMove.setSelect && selection==true) 
			if (mainMenuSelect==true) {
				uiPicker(menuPoint);
				//mapUI();
				cameraMove.mapMove ();
			}

			break;
		}
			
	}


	//This assigns all of the button features
	public void getButtons()
	{
		settingButton = GameObject.Find ("Setting").GetComponent<UnityEngine.UI.Button> ();
		playerButton =  GameObject.Find ("Player Actions").GetComponent<UnityEngine.UI.Button> ();
		waypointButton = GameObject.Find ("Waypoint Actions").GetComponent<UnityEngine.UI.Button> ();
		mapButton = GameObject.Find ("Map Control").GetComponent<UnityEngine.UI.Button> ();
	}


	//This allows the jump from map to settings and settings to map
	public void checkMenuPoint()
	{
		if (menuPoint > 3 ) {
			menuPoint = 0;
		} 
		else if (menuPoint < 0) {
			menuPoint = 3;
		}
	}

	//This handles the highlighting when using wasd
	public void checkSelected()
	{
		if (menuPoint == 0) {
			settingButton.OnSelect (null);
			playerButton.OnDeselect (null);
			waypointButton.OnDeselect (null);
			mapButton.OnDeselect (null);
		}
		else if (menuPoint == 1){
			playerButton.OnSelect (null);
			settingButton.OnDeselect (null);
			waypointButton.OnDeselect (null);
			mapButton.OnDeselect (null);
		}
		else if (menuPoint == 2){
			waypointButton.OnSelect (null);
			settingButton.OnDeselect (null);
			playerButton.OnDeselect (null);
			mapButton.OnDeselect (null);
		}
		else if (menuPoint == 3){
			mapButton.OnSelect (null);
			settingButton.OnDeselect (null);
			waypointButton.OnDeselect (null);
			playerButton.OnDeselect (null);
		}
	}



	public void checkCameraMove()
	{
		if (menuPoint == 3) {
			cameraMove.setSelect = true;
		} else {
			cameraMove.setSelect = false;
		}
	}


	//These are for the buttons to for clicking/touchscreen
	public void selectMap()
	{
		menuPoint = 3;
		mainMenuSelect = true;
		Debug.Log ("Map Selected");
		uiPicker(3);
		//mapUI();

	}

	public void selectWaypoints()
	{
		menuPoint = 2;
		uiPicker(2);
		Debug.Log ("Waypoints selected");
	}

	public void selectPlayer()
	{
		menuPoint = 1;
		//agentUI();
		uiPicker(1);
		Debug.Log ("Player selected");
	}

	public void selectSetting()
	{
		menuPoint = 0;
		Debug.Log ("Setting selected");
	}

	//This is for controlling the main selection
	public void getInput()
	{
		
			if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
				//If we are navigating the main menu
				if (mainMenuSelect == false && agentMenuSelect == false) {
					Debug.Log (menuPoint);
					menuPoint--;
				} 
				//If we are navigating the action menu
				else if (agentActionSelect == true) {
					actionPoint--;
				} 
			}
			if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
				//If we are navigating the main menu
				if (mainMenuSelect == false && agentMenuSelect == false) {
					Debug.Log (menuPoint);
					menuPoint++;
				}
				//If we are navigating the action menu
				else if (agentActionSelect == true) {
					actionPoint++;
				}
			}


		if (Input.GetKeyDown (KeyCode.D) || Input.GetKey (KeyCode.LeftArrow))
		{
				//If we are navigating the agent select
				if (agentMenuSelect && !agentActionSelect) 
			{
					//Navigates the possible agents
					userControl.NextAgent ();
			} 
				//If we are navigating the agent action menu
			else if (agentActionSelect) 
			{
				
				//If we are changing routes
				if (actionPoint == 0) {
					//Gets next route
					userControl.nextRoute ();

					if (userControl.activeRouteLabel != null) {
						routeDataLabel.text = userControl.activeRouteLabel.text;
					}
				} 
				//Navigating Waypoints
				else if (actionPoint == 1) {
					//Gets next waypoint
					userControl.nextWayPoint ();

					if (userControl.activeRouteLabel != null) {
						waypointDataLabel.text = userControl.activeWayPointLabel.text;
					}
				} 
				//Navigating Tasks
				else if (actionPoint == 4)
				{
					//Gets next task
					userControl.nextTask();

					if (userControl.activeRouteLabel != null) {
						taskDataLabel.text = userControl.activeTaskLabel.text;
					}
				}

			}
		} 
		else if (Input.GetKeyDown (KeyCode.A) || Input.GetKey (KeyCode.RightArrow)) 
		{
				//If we are navigating the agent select
				if (agentMenuSelect && !agentActionSelect) 
			{
				//Gets the previous agent
					userControl.PrevAgent ();
			}
				//If we are navigating the action select
			else if (agentActionSelect) 
			{
				//Navigating Routes
				if (actionPoint == 0) 
				{
					userControl.prevRoute ();
					
						if (userControl.activeRouteLabel != null) {
							routeDataLabel.text = userControl.activeRouteLabel.text;
						}
				}
				//Navigating Waypoints
				else if (actionPoint == 1) 
				{
					//Gets the previous waypoint
					userControl.prevWayPoint();

					if (userControl.activeRouteLabel != null) 
					{
						waypointDataLabel.text = userControl.activeWayPointLabel.text;
					}
				}
				//Navigating Tasks
				else if (actionPoint == 4)
				{
					//Gets the previous task
					userControl.prevTask();

					if (userControl.activeRouteLabel != null) {
						taskDataLabel.text = userControl.activeTaskLabel.text;

					}
				}
			}
		}

			

			if (Input.GetKeyDown (KeyCode.C)) {
					//Hitting C over a main menu option will now open the next part of the menu
					mainMenuSelect = true;
				if (agentMenuSelect == true) {
					agentActionSelect = true;
				//This makes the routes display when the action menu pops up
				routeDataLabel.text = userControl.activeRouteLabel.text;
				waypointDataLabel.text = userControl.activeWayPointLabel.text;
				taskDataLabel.text = userControl.activeTaskLabel.text;
				}


				Debug.Log ("Setting selection" + mainMenuSelect);
			}

	   

			if (Input.GetKeyDown (KeyCode.B)) {

				//If we are in action select and want to go back
				if (mainMenuSelect == true && agentMenuSelect == true && agentActionSelect == true) {
					agentActionSelect = false;
				//If we are in the agent select and want to go back
				} else if (mainMenuSelect == true && agentMenuSelect == true && agentActionSelect == false) {
					agentMenuSelect = false;
					mainMenuSelect = false;
				} else if (mainMenuSelect == true) {
					mainMenuSelect = false;
				}

					cameraMove.setSelect = false;

					mainMenuUI ();
			}

		
		if (Input.GetKeyDown (KeyCode.T)) 
		{
			Debug.Log ("Plus pressed");
			//If we confirm while over the waypoints, set the current agents waypoint 
			if (actionPoint == 1) {
				//Add code to store the actual waypoint data
				userControl.activeAgentDataLabel.text = waypointDataLabel.text;
				//This might need to be changed
				userControl.PushWayPointToAgent ();
				Debug.Log ("Plus pressed inside waypoint");
			} else if (actionPoint == 4) 
			{
				taskDataLabel.text = userControl.activeTaskLabel.text;

				if (taskDataLabel.text == "Task: moveNow")
				{
					moving = true;
				}



				//userControl.activeTaskLabel.text = taskDataLabel.text;
				userControl.PushTaskToAgent();
			}
		}

		if (moving) 
		{
			taskToDo.doTask ("moveNow");
		}


		WayPoint wayPoint = new WayPoint (33.95, -118.45, 49, "NPSGate");

		Vector2d latLong = new Vector2d(wayPoint.mLatitude, wayPoint.mLongitude);
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			moveAgent.transform.localPosition = Conversions.GeoToWorldPosition(latLong, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();
		}




	}


	public void uiPicker(int pick)
	{
		switch (pick)
		{
		case 0:
			//Code for other menu
			break;
		case 1:
			//Code for other menu
			agentUI();
			break;
		case 2:
			//Code for other menu
			routeUI();
			break;
		case 3:
				mapUI();
			break;
		}
	}

	public void mainMenuUI()
	{
		mainMenuPanel.gameObject.SetActive(true);
		agentPanel.gameObject.SetActive(true);
		debugPanel.gameObject.SetActive(false);
		routePanel.gameObject.SetActive (false);
	}

	public void mapUI()
	{
		mainMenuPanel.gameObject.SetActive(false);
		agentPanel.gameObject.SetActive(false);
		debugPanel.gameObject.SetActive(false);
		routePanel.gameObject.SetActive (false);
	}

	public void agentUI()
	{
		mainMenuPanel.gameObject.SetActive(false);
		agentPanel.gameObject.SetActive(true);
		debugPanel.gameObject.SetActive(false);
		routePanel.gameObject.SetActive (false);
	}

	public void waypointUI()
	{
		mainMenuPanel.gameObject.SetActive(false);
		agentPanel.gameObject.SetActive(false);
		debugPanel.gameObject.SetActive(false);
		routePanel.gameObject.SetActive (false);
	}

	public void routeUI()
	{
		routePanel.gameObject.SetActive (true);
		mainMenuPanel.gameObject.SetActive(false);
		agentPanel.gameObject.SetActive(false);
		debugPanel.gameObject.SetActive(false);
	}

	public void getPanels()
	{
		mainMenuPanel = GameObject.Find("Menu Panel");
		agentPanel = GameObject.Find("AgentPanel");
		debugPanel = GameObject.Find("DebugBlackboard");
		routePanel = GameObject.Find("RoutePanel");
	}




	//This adds all the text values to a list in order to make highlighting easier
	private void addLabels()
	{
		allLabels.Add (routeDataLabel);
		allLabels.Add (waypointDataLabel);
		allLabels.Add (factionDataLabel);
		allLabels.Add (agentDataLabel);
		allLabels.Add (taskDataLabel);
	}

	//This makes sure we can move through the action panel
	public void checkActionPoint()
	{
		if (actionPoint > 4 ) {
			actionPoint = 0;
		} 
		else if (actionPoint < 0) {
			actionPoint = 4;
		}
	}

	//This checks which text value to highlight for the action panel
	public void checkActionSelected()
	{
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
			if (!(thisLabel.Equals(label)) ) 
			{
				label.color = Color.white;
			}
		}			
	}


}
