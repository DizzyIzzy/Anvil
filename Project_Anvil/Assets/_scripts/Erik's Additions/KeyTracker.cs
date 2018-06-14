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
	public int settingPoint = 0;

	//References to other scripts
	CameraController cameraMove;
	public UIControlScript userControl;
	//public MasterBlackBoard blackBoard;
	public Tasks taskToDo;
	public UIHandler uiHandler;

	//This determines which selection we are using
	public bool mainMenuSelect;
	public bool agentMenuSelect;
	public bool agentActionSelect;
	public bool settingSelect;



	public GameObject actionMenuPanel;

	//public GameObject moveAgent;

	//Booleans
	public bool moving;
    
	void Start () {
		agentActionSelect = false;
		mainMenuSelect = false;
		settingSelect = false;
		moving = false;

		cameraMove = GetComponent(typeof(CameraController)) as CameraController;
		taskToDo = GetComponent<Tasks> ();
		uiHandler = GetComponent<UIHandler>();

		actionMenuPanel.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		checkMenuPoint ();
		checkCameraMove ();
		getInput ();

		//uiHandler.checkMainMenuSelected(menuPoint);

		//This helps highlight the different main menu options
		switch (menuPoint)
		{
		case 0:
				//Code for setting menu
			if (mainMenuSelect == true)
			{
				uiHandler.uiPicker(menuPoint);
			}
			settingSelect = true;
			break;
		case 1:
			//This is the case for the agent menu
			if(mainMenuSelect==true)
			{
			uiHandler.uiPicker(menuPoint);
			agentMenuSelect = true;
				//If we are already in the agent Menu and now we go into the action menu
				if (agentActionSelect == true) {
					actionMenuPanel.gameObject.SetActive (true);
					//agentPanel.gameObject.SetActive (false);
					checkActionPoint ();
					//uiHandler.checkActionSelected (actionPoint);
				} else {
					actionMenuPanel.gameObject.SetActive (false);
					//agentPanel.gameObject.SetActive (true);
				}
			}
			break;
		case 2:
			//Code for waypoint menu
			if(mainMenuSelect==true)
			{
			uiHandler.uiPicker(menuPoint);
			//waypointUI();
			}
			break;
		case 3:
			//Code for camera menu
			//if (cameraMove.setSelect && selection==true) 
			if (mainMenuSelect==true) {
				uiHandler.uiPicker(menuPoint);
				//mapUI();
				cameraMove.mapMove ();
			}

			break;
		}
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
				else if (settingSelect)
			{


			}
				//If we are navigating the agent action menu
				else if (agentActionSelect) 
				{
				
				//If we are changing routes
				if (actionPoint == 0) {
					//Gets next route
					userControl.nextRoute ();

					if (userControl.activeRouteLabel != null) {
						//routeDataLabel.text = userControl.activeRouteLabel.text;
						uiHandler.routeDataLabel.text = userControl.activeRouteLabel.text;
					}
				} 
				//Navigating Waypoints
				else if (actionPoint == 1) {
					//Gets next waypoint
					userControl.nextWayPoint ();

					if (userControl.activeRouteLabel != null) {
						//waypointDataLabel.text = userControl.activeWayPointLabel.text;
						uiHandler.waypointDataLabel.text = userControl.activeWayPointLabel.text;
					}
				} 
				//Navigating Tasks
				else if (actionPoint == 4)
				{
					//Gets next task
					userControl.nextTask();

					if (userControl.activeRouteLabel != null) {
						//taskDataLabel.text = userControl.activeTaskLabel.text;
						uiHandler.taskDataLabel.text = userControl.activeTaskLabel.text;

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
				else if (settingSelect)
			{

			}

			//If we are navigating the action select
			else if (agentActionSelect) 
			{
				//Navigating Routes
				if (actionPoint == 0) 
				{
					userControl.prevRoute ();
					
						if (userControl.activeRouteLabel != null) {
							//routeDataLabel.text = userControl.activeRouteLabel.text;
							uiHandler.routeDataLabel.text = userControl.activeRouteLabel.text;
					}
				}
				//Navigating Waypoints
				else if (actionPoint == 1) 
				{
					//Gets the previous waypoint
					userControl.prevWayPoint();

					if (userControl.activeRouteLabel != null) 
					{
						//waypointDataLabel.text = userControl.activeWayPointLabel.text;
						uiHandler.waypointDataLabel.text = userControl.activeWayPointLabel.text;
					}
				}
				//Navigating Tasks
				else if (actionPoint == 4)
				{
					//Gets the previous task
					userControl.prevTask();

					if (userControl.activeRouteLabel != null) {
						//taskDataLabel.text = userControl.activeTaskLabel.text;
						uiHandler.taskDataLabel.text = userControl.activeTaskLabel.text;

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
				uiHandler.routeDataLabel.text = userControl.activeRouteLabel.text;
				uiHandler.waypointDataLabel.text = userControl.activeWayPointLabel.text;
				uiHandler.taskDataLabel.text = userControl.activeTaskLabel.text;
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
            	uiHandler.mainMenuUI ();
			}

		
		if (Input.GetKeyDown (KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Equals)) 
		{
			Debug.Log ("Plus pressed");
			//If we confirm while over the waypoints, set the current agents waypoint 
			if (actionPoint == 1) {
                //Add code to store the actual waypoint data
                userControl.selectedAgent.setNavTarget(userControl.activeWayPoint);
                userControl.activeAgentDataLabel.text = uiHandler.waypointDataLabel.text;
				//This might need to be changed
				userControl.PushWayPointToAgent ();
				Debug.Log ("Plus pressed inside waypoint");
			} else if (actionPoint == 4) 
			{
				uiHandler.taskDataLabel.text = userControl.activeTaskLabel.text;

				if (uiHandler.taskDataLabel.text == "Task: moveNow")
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

	//This allows the jump from map to settings and settings to map
	public void checkMenuPoint()
	{
		if (menuPoint > 3)
		{
			menuPoint = 0;
		}
		else if (menuPoint < 0)
		{
			menuPoint = 3;
		}
	}


	public void checkCameraMove()
	{
		if (menuPoint == 3)
		{
			cameraMove.setSelect = true;
		}
		else
		{
			cameraMove.setSelect = false;
		}
	}

	//These are for the buttons to for clicking/touchscreen
	public void selectMap()
	{
		menuPoint = 3;
		mainMenuSelect = true;
		Debug.Log("Map Selected");
		uiHandler.uiPicker(3);
		//mapUI();
	}

	public void selectWaypoints()
	{
		menuPoint = 2;
		uiHandler.uiPicker(2);
		Debug.Log("Waypoints selected");
	}

	public void selectPlayer()
	{
		menuPoint = 1;
		//agentUI();
		uiHandler.uiPicker(1);
		Debug.Log("Player selected");
	}

	public void selectSetting()
	{
		menuPoint = 0;
		Debug.Log("Setting selected");
	}

}
