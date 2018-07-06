using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentPanel : MonoBehaviour {

	public Text agentPosText;
	public Text navDataText;

	// active agent
	public AnvilAgent selectedAgent;
	public List<AnvilAgent> allFactionAgents;

	private int agentCount;
	public int agentIndex = 0;

	public UIControlScript uiControlScript;


	// Use this for initialization
	void Start () {
		agentPosText = GameObject.Find("AgentPosText").GetComponent<UnityEngine.UI.Text>();
		navDataText = GameObject.Find("NavDataText").GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void GetLeftInput()
	{
		Debug.Log("Previous Agent");
		//uiControlScript.NextAgent();
		NextAgent();
	}
	public void GetRightInput()
	{
		Debug.Log("Next Agent");
		//uiControlScript.PrevAgent();
		PrevAgent();

	}
	public void GetUpInput()
	{

	}
	public void GetDownInput()
	{

	}

	public void NextAgent()
	{
		MasterBlackBoard.ReadWayPointsFromFile();
		allFactionAgents = MasterBlackBoard.allGameAgents;
		if (allFactionAgents == null)
		{ MasterBlackBoard.RefreshAllAgentsList(); }
		agentCount = allFactionAgents.Count;
		int nextAgentIndex = agentIndex + 1;
		if (nextAgentIndex >= agentCount)
		{
			agentIndex = 0;
		}
		else
		{
			agentIndex = nextAgentIndex;
		}
		UpdateAgentUIInfo();
	}

	public void PrevAgent()
	{
		allFactionAgents = MasterBlackBoard.allGameAgents;

		if (allFactionAgents == null)
		{ MasterBlackBoard.RefreshAllAgentsList(); }
		agentCount = allFactionAgents.Count;
		int prevAgentIndex = agentIndex - 1;
		if (prevAgentIndex < 0)
		{
			agentIndex = agentCount - 1;
		}
		else
		{
			agentIndex = prevAgentIndex;
		}
		UpdateAgentUIInfo();
	}

	public void UpdateAgentUIInfo()
	{
		selectedAgent = allFactionAgents[agentIndex];
		MasterBlackBoard.setActiveAgent(selectedAgent);
		if (selectedAgent != null)
		{
			// activeAgentLabel.text = selectedAgent.agentName;
			if (selectedAgent.locationLatLng != null)
			{
				agentPosText.text = selectedAgent.getAgentBlackBoardDataString();
			}

			navDataText.text = selectedAgent.getAgentBlackBoardDataString();


			//activeAgentPosLabel.text = selectedAgent.mLocation.ToString() + "*\n +" +
			//  ConversionTool.LatLongToUnityVector3D(selectedAgent.mLocation);
			//  if (selectedAgent.navTarget == null)
			//          {  activeAgentDataLabel.text = "- no waypoint";}
			//     else {  activeAgentDataLabel.text = selectedAgent.navTarget.mWayPointName;}

			//    if (selectedAgent.sensorTarget == null)
			//      { activeAgentDataLabel.text = "- no SPI"; }
			//     else { activeAgentDataLabel.text = selectedAgent.navTarget.mWayPointName; }

			//       if (selectedAgent.task == "")
			//		{   activeTaskLabel.text = "Task: Idle";
			//	} else{activeTaskLabel.text = selectedAgent.task}

		}
	}



















}
