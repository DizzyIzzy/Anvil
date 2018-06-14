using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointPanel : MonoBehaviour {
	public Text activeRouteData;
	public Text activeWptData;
	public Text wptData;


	// Use this for initialization
	void Start () {
		activeRouteData = GameObject.Find("ActiveRouteData").GetComponent<UnityEngine.UI.Text>();
		activeWptData = GameObject.Find("ActiveWptData").GetComponent<UnityEngine.UI.Text>();
		wptData = GameObject.Find("WptData").GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetLeftInput()
	{
		Debug.Log("Past Waypoint");
	}
	public void GetRightInput()
	{
		Debug.Log("Next Waypoint");
	}
	public void GetUpInput()
	{
		Debug.Log("Up Waypoint");
	}
	public void GetDownInput()
	{
		Debug.Log("Down Waypoint");
	}
}
