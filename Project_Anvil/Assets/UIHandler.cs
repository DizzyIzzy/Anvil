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
