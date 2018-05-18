using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour {

	KeyTracker keyTracker;
	UserControlScript buttonControl;
	private GameObject routePanel;
	private GameObject taskPanel;
	private GameObject targetingPanel;

	int menuPoint;

	// Use this for initialization
	void Start () {
		menuPoint = 1;
		keyTracker = GetComponent(typeof(KeyTracker)) as KeyTracker;
		buttonControl = GetComponent (typeof(UserControlScript)) as UserControlScript;
		routePanel = GameObject.Find ("RoutePanel");
		taskPanel = GameObject.Find ("TaskPanel");
		targetingPanel = GameObject.Find ("TargetingPanel");
		waypointUI ();
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


		if (Input.GetKeyDown (KeyCode.B)) {

			//setSelect = false;
			keyTracker.selection = false;
			//mainMenuPanel.gameObject.SetActive(true);
			//keyTracker.menuPoint++;
			//Debug.Log ("B was pressed" + keyTracker.selection);
		}

		agentUIPicker (menuPoint);



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
		}

		public void targetingUI(){
			taskPanel.gameObject.SetActive(false);
			routePanel.gameObject.SetActive(false);
			targetingPanel.gameObject.SetActive(true);
		}

		public void taskUI(){
			routePanel.gameObject.SetActive(false);
			targetingPanel.gameObject.SetActive(false);
			taskPanel.gameObject.SetActive(true);
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



}
