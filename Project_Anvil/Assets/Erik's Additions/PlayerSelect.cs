using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect: MonoBehaviour {

	KeyTracker keyTracker;
	UserControlScript buttonControl;
	private GameObject routePanel;
	private GameObject taskPanel;
	private GameObject targetingPanel;
	public GameObject mainMenuPanel;
	public GameObject agentPanel;

	public GameObject thisPanel;

	public bool selection;

	int menuPoint;

	// Use this for initialization
	void Start () {
		menuPoint = 1;
		keyTracker = GetComponent(typeof(KeyTracker)) as KeyTracker;
		buttonControl = GetComponent (typeof(UserControlScript)) as UserControlScript;
		routePanel = GameObject.Find ("RoutePanel");
		taskPanel = GameObject.Find ("TaskPanel");
		targetingPanel = GameObject.Find ("TargetingPanel");
		mainMenuPanel = GameObject.Find("Menu Panel");
		agentPanel = GameObject.Find("AgentPanel");
		waypointUI ();
		selection = true;
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void agentInputs()
	{
		getInput ();
	}


	public void getInput()
	{
		Debug.Log (menuPoint);

		if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow))
		{
			buttonControl.NextAgent ();
		}
		else if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.RightArrow)) 
		{
			buttonControl.PrevAgent ();
		}




		if (Input.GetKeyDown (KeyCode.B)) {
			exitUI ();
			keyTracker.selection = false;
			mainMenuPanel.gameObject.SetActive(true);
		}


		if (Input.GetKeyDown (KeyCode.C)) {
			if (selection == false) {
				selection = true;
			} else {
				selection = false;
			}
			Debug.Log (selection);
			//selection = true;
		}

		checkSelection ();
		agentUIPicker (menuPoint);



	}


	public void checkSelection()
	{
		if (selection) {
			if (  Input.GetKeyDown(KeyCode.W)  || Input.GetKey(KeyCode.UpArrow)) 
			{

				menuPoint--;
				checkMenuPoint ();

			}
			else if ( Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
			{
				menuPoint++;
				checkMenuPoint ();

			}
		}
	}

		

		public void agentUIPicker(int pick)
		{
			switch (pick)
			{
			case 1:
				waypointUI();
				break;
			case 2:
				targetingUI();
				break;
			case 3:
				taskUI();
				break;
			
			}
		}

		public void waypointUI(){
			
			taskPanel.gameObject.SetActive(false);
			targetingPanel.gameObject.SetActive(false);
			routePanel.gameObject.SetActive(true);
			thisPanel = routePanel;
		}

		public void targetingUI(){
			taskPanel.gameObject.SetActive(false);
			routePanel.gameObject.SetActive(false);
			targetingPanel.gameObject.SetActive(true);
			thisPanel = targetingPanel;
		}

		public void taskUI(){
			routePanel.gameObject.SetActive(false);
			targetingPanel.gameObject.SetActive(false);
			taskPanel.gameObject.SetActive(true);
		    thisPanel = taskPanel;
		}


	public void checkMenuPoint()
	{
		if (menuPoint > 3 ) {
			menuPoint = 1;
		} 
		else if (menuPoint < 1) {
			menuPoint = 3;
		}
	}

	public void exitUI(){
		agentPanel.gameObject.SetActive (true);
		thisPanel.gameObject.SetActive(true);
	}



}
