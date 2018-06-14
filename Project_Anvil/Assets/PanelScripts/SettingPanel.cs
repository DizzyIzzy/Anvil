using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour {
	public GameObject settingsPanel;

	private UnityEngine.UI.Button optionsButton;
	private UnityEngine.UI.Button controlsButton;
	private UnityEngine.UI.Button filesButton;
	private UnityEngine.UI.Button networkButton;

	public List<UnityEngine.UI.Button> allButtons;

	private int selectionIndex;

	// Use this for initialization
	void Start () {
		selectionIndex = 0;
		settingsPanel = GameObject.Find("SettingsPanel");
		getButtons();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetUpInput()
	{

	}
	public void GetDownInput()
	{

	}

	public void GetRightInput()
	{
		selectionIndex++;
		checkSelectionIndex();
		Debug.Log("Selection Index: " + selectionIndex);
	}

	public void GetLeftInput()
	{
		selectionIndex--;
		checkSelectionIndex();
		Debug.Log("Selection Index: " + selectionIndex);
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
		optionsButton = GameObject.Find("OptionsButton").GetComponent<UnityEngine.UI.Button>();
		controlsButton = GameObject.Find("ControlsButton").GetComponent<UnityEngine.UI.Button>();
		filesButton = GameObject.Find("FilesButton").GetComponent<UnityEngine.UI.Button>();
		networkButton = GameObject.Find("NetworkButton").GetComponent<UnityEngine.UI.Button>();

		allButtons.Add(optionsButton);
		allButtons.Add(controlsButton);
		allButtons.Add(filesButton);
		allButtons.Add(networkButton);

	}

	public void checkMainMenuSelected(int selectionIndex)
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






}
