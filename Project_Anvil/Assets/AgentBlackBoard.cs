using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBlackBoard : MonoBehaviour {


	BlackBoardScript blackBoard;
	public List<WayPoint> agentWayPoints;

	// Use this for initialization
	void Start () {
		blackBoard = GetComponent(typeof(BlackBoardScript)) as BlackBoardScript;
		agentWayPoints = blackBoard.allGameWayPoints;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
