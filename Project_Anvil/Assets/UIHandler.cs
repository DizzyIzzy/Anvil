using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHandler : MonoBehaviour {

	//Panels for UI
	public GameObject mainMenuPanel;
	public GameObject agentPanel;
	public GameObject debugPanel;
	public GameObject actionMenuPanel;
	public GameObject routePanel;
	public GameObject settingsPanel;

	//Buttons for Main Menu
	private UnityEngine.UI.Button settingButton;
	private UnityEngine.UI.Button playerButton;
	private UnityEngine.UI.Button waypointButton;
	private UnityEngine.UI.Button mapButton;

	//Buttons for settings Menu
	private UnityEngine.UI.Button optionsButton;
	private UnityEngine.UI.Button controlsButton;
	private UnityEngine.UI.Button filesButton;
	private UnityEngine.UI.Button networkButton;


	//For highlighting in the action menu
	public Text routeDataLabel;
	public Text waypointDataLabel;
	public Text factionDataLabel;
	public Text agentDataLabel;
	public Text taskDataLabel;

	private Text thisLabel;
	private List<Text> allLabels;


	// Use this for initialization
	void Start () {
		allLabels = new List<Text>();
		getPanels();
		getButtons();
		getLabels();
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	//Switch case to see which panel we want 
	public void uiPicker(int pick)
	{
		switch (pick)
		{
			case 0:
				mainMenuUI();
				break;
			case 1:
				settingsUI();
				break;
			case 2:
				agentUI();
				break;
			case 3:
				routeUI();
				break;
			case 4:
				mapUI();
				break;
		}
	}


	//Checks which button we will highlight in Main Menu
	/*
	public void checkMainMenuSelected(int selectionIndex)
	{
		switch (selectionIndex)
		{
			case 0:
				settingButton.OnSelect(null);
				playerButton.OnDeselect(null);
				waypointButton.OnDeselect(null);
				mapButton.OnDeselect(null);
				break;
			case 1:
				playerButton.OnSelect(null);
				settingButton.OnDeselect(null);
				waypointButton.OnDeselect(null);
				mapButton.OnDeselect(null);
				break;
			case 2:
				waypointButton.OnSelect(null);
				settingButton.OnDeselect(null);
				playerButton.OnDeselect(null);
				mapButton.OnDeselect(null);
				break;
			case 3:
				mapButton.OnSelect(null);
				settingButton.OnDeselect(null);
				waypointButton.OnDeselect(null);
				playerButton.OnDeselect(null);
				break;

		}
	}

	//Checks which button we will highlight in settings menu
	public void checkSettingMenuSelected(int selectionIndex)
	{
		switch (selectionIndex)
		{
			case 0:
				optionsButton.OnSelect(null);
				controlsButton.OnDeselect(null);
				filesButton.OnDeselect(null);
				networkButton.OnDeselect(null);
				break;
			case 1:
				controlsButton.OnSelect(null);
				optionsButton.OnDeselect(null);
				filesButton.OnDeselect(null);
				networkButton.OnDeselect(null);
				break;
			case 2:
				filesButton.OnSelect(null);
				controlsButton.OnDeselect(null);
				optionsButton.OnDeselect(null);
				networkButton.OnDeselect(null);
				break;
			case 3:
				networkButton.OnSelect(null);
				controlsButton.OnDeselect(null);
				filesButton.OnDeselect(null);
				optionsButton.OnDeselect(null);
				break;

		}
	}
	*/

	/*
	public void checkActionSelected(int actionPoint)
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
			if (!(thisLabel.Equals(label)))
			{
				label.color = Color.white;
			}
		}
	}
	*/





	public void getPanels()
	{
		mainMenuPanel = GameObject.Find("Menu Panel");
		agentPanel = GameObject.Find("AgentPanel");
		debugPanel = GameObject.Find("DebugBlackboard");
		routePanel = GameObject.Find("RoutePanel");
		settingsPanel = GameObject.Find("SettingsPanel");
		actionMenuPanel = GameObject.Find("actionMenuPanel");
	}

	public void getButtons()
	{
		settingButton = GameObject.Find("Setting").GetComponent<UnityEngine.UI.Button>();
		playerButton = GameObject.Find("Player Actions").GetComponent<UnityEngine.UI.Button>();
		waypointButton = GameObject.Find("Waypoint Actions").GetComponent<UnityEngine.UI.Button>();
		mapButton = GameObject.Find("Map Control").GetComponent<UnityEngine.UI.Button>();
		optionsButton = GameObject.Find("OptionsButton").GetComponent<UnityEngine.UI.Button>();
		controlsButton = GameObject.Find("ControlsButton").GetComponent<UnityEngine.UI.Button>();
		filesButton = GameObject.Find("FilesButton").GetComponent<UnityEngine.UI.Button>();
		networkButton = GameObject.Find("NetworkButton").GetComponent<UnityEngine.UI.Button>();
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

	public void mainMenuUI()
	{
		mainMenuPanel.gameObject.SetActive(true);
		agentPanel.gameObject.SetActive(true);
		debugPanel.gameObject.SetActive(false);
		routePanel.gameObject.SetActive(false);
		settingsPanel.gameObject.SetActive(false);
	}

	public void mapUI()
	{
		mainMenuPanel.gameObject.SetActive(false);
		agentPanel.gameObject.SetActive(false);
		debugPanel.gameObject.SetActive(false);
		routePanel.gameObject.SetActive(false);
		settingsPanel.gameObject.SetActive(false);
	}

	public void agentUI()
	{
		mainMenuPanel.gameObject.SetActive(false);
		agentPanel.gameObject.SetActive(true);
		debugPanel.gameObject.SetActive(false);
		routePanel.gameObject.SetActive(false);
		settingsPanel.gameObject.SetActive(false);
	}

	public void waypointUI()
	{
		mainMenuPanel.gameObject.SetActive(false);
		agentPanel.gameObject.SetActive(false);
		debugPanel.gameObject.SetActive(false);
		routePanel.gameObject.SetActive(false);
		settingsPanel.gameObject.SetActive(false);
	}

	public void routeUI()
	{
		routePanel.gameObject.SetActive(true);
		mainMenuPanel.gameObject.SetActive(false);
		agentPanel.gameObject.SetActive(false);
		debugPanel.gameObject.SetActive(false);
		settingsPanel.gameObject.SetActive(false);
	}

	public void settingsUI()
	{
		routePanel.gameObject.SetActive(false);
		mainMenuPanel.gameObject.SetActive(false);
		agentPanel.gameObject.SetActive(false);
		debugPanel.gameObject.SetActive(false);
		settingsPanel.gameObject.SetActive(true);
	}



}
