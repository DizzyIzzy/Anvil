using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentPanel : MonoBehaviour {

	public Text agentPosText;
	public Text navDataText;


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
	}
	public void GetRightInput()
	{
		Debug.Log("Next Agent");
	}
	public void GetUpInput()
	{

	}
	public void GetDownInput()
	{

	}
}
