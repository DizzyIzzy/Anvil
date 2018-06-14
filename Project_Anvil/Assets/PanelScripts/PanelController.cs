using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {

	public GameObject MenuPanel;
	public GameObject AgentPanel;
	public GameObject actionMenuPanel;

	public List<GameObject> listOfPanels;
	public int panelIndex;

	// Use this for initialization
	void Start () {
		listOfPanels = new List<GameObject>();
		panelIndex = 0;
		addPanels();

		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.C))
		{
			panelIndex++;
			checkPanelIndex();
		}

		if(Input.GetKeyDown(KeyCode.B))
		{
			panelIndex--;
			checkPanelIndex();
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

	}



	public void addPanels()
	{
		MenuPanel = GameObject.Find("Menu Panel");
		AgentPanel = GameObject.Find("AgentPanel");
		actionMenuPanel = GameObject.Find("actionMenuPanel");

		listOfPanels.Add(MenuPanel);
		listOfPanels.Add(AgentPanel);
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
