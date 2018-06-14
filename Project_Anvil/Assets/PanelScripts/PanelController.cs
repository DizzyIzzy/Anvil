using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {

	public GameObject MenuPanel;
	public GameObject AgentPanel;
	public GameObject actionMenuPanel;
	public GameObject SettingsPanel;
	public GameObject WaypointPanel;
	public GameObject MapPanel;

	public List<GameObject> listOfPanels;
	public int panelIndex;
	public int mainMenuPanelIndex;


	public UIHandler uiHandler;

	// Use this for initialization
	void Start () {
		listOfPanels = new List<GameObject>();
		
		panelIndex = 0;
		addPanels();

		uiHandler = GetComponent<UIHandler>();

		mainMenuPanelIndex = MenuPanel.GetComponent<MainMenuPanel>().selectionIndex;


	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(mainMenuPanelIndex);

		//This will have to change to show different panels
		//uiHandler.uiPicker(mainMenuPanelIndex);

		//This might need to get some clean up later on 
		//We are doing these checks to see where in the array of panels we want to be in
		if (Input.GetKeyDown(KeyCode.C))
		{
			//If we are in the Agent panel and want to go to the action panel
			if (panelIndex == 2)
			{
				panelIndex = 5;
			}
			else
			{
				panelIndex = mainMenuPanelIndex + 1;
			}

			Debug.Log("Panel Index: " + panelIndex);
			checkPanelIndex();






		}

		if(Input.GetKeyDown(KeyCode.B))
		{
			//panelIndex--;
			checkPanelIndex();

			//If we are in the action panel and want to go back to the agent panel
			if (panelIndex == 5)
			{
				panelIndex = 2;
			}
			else if (panelIndex < 5 )
			{
				panelIndex = 0;
			}




		}


		if(Input.GetKeyDown(KeyCode.W))
		{
			listOfPanels[panelIndex].SendMessage("GetUpInput");
		}
		
		if(Input.GetKeyDown(KeyCode.S))
		{
			listOfPanels[panelIndex].SendMessage("GetDownInput");
		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			listOfPanels[panelIndex].SendMessage("GetLeftInput");
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			listOfPanels[panelIndex].SendMessage("GetRightInput");
		}



		mainMenuPanelIndex = MenuPanel.GetComponent<MainMenuPanel>().selectionIndex;
	}



	public void addPanels()
	{
		MenuPanel = GameObject.Find("Menu Panel");
		SettingsPanel = GameObject.Find("SettingsPanel");
		AgentPanel = GameObject.Find("AgentPanel");
		WaypointPanel = GameObject.Find("RoutePanel");
		MapPanel = GameObject.Find("MapPanel");
		actionMenuPanel = GameObject.Find("actionMenuPanel");
		

		listOfPanels.Add(MenuPanel);
		listOfPanels.Add(SettingsPanel);
		listOfPanels.Add(AgentPanel);
		listOfPanels.Add(WaypointPanel);
		listOfPanels.Add(MapPanel);
		listOfPanels.Add(actionMenuPanel);
		
	}

	public void checkPanelIndex()
	{
		if(panelIndex < 0)
		{
			panelIndex = 0;
		}
		if(panelIndex == listOfPanels.Count)
		{
			panelIndex = listOfPanels.Count - 1;
		}


	}

}
