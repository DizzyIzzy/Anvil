using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : MonoBehaviour {
	public GameObject mainMenuPanel;

	private UnityEngine.UI.Button settingButton;
	private UnityEngine.UI.Button playerButton;
	private UnityEngine.UI.Button waypointButton;
	private UnityEngine.UI.Button mapButton;

	public List<UnityEngine.UI.Button> allButtons;

	private int selectionIndex;

	// Use this for initialization
	void Start () {
		selectionIndex = 0;
		mainMenuPanel = GameObject.Find("Menu Panel");
		getButtons();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetUpInput()
	{
		selectionIndex--;
		checkSelectionIndex();
	}
	public void GetDownInput()
	{
		selectionIndex++;
		checkSelectionIndex();
	}

	public void GetRightInput()
	{

	}

	public void GetLeftInput()
	{

	}


	public void checkSelectionIndex()
	{
		if (selectionIndex > 3)
		{
			selectionIndex = 0;
		}
		if (selectionIndex < 0)
		{
			selectionIndex = 3;
		}

		checkMainMenuSelected(selectionIndex);
	}



	public void getButtons()
	{
		settingButton = GameObject.Find("Setting").GetComponent<UnityEngine.UI.Button>();
		playerButton = GameObject.Find("Player Actions").GetComponent<UnityEngine.UI.Button>();
		waypointButton = GameObject.Find("Waypoint Actions").GetComponent<UnityEngine.UI.Button>();
		mapButton = GameObject.Find("Map Control").GetComponent<UnityEngine.UI.Button>();

		allButtons.Add(settingButton);
		allButtons.Add(playerButton);
		allButtons.Add(waypointButton);
		allButtons.Add(mapButton);
		
	}

	public void checkHighlight()
	{
		
	}


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



}
