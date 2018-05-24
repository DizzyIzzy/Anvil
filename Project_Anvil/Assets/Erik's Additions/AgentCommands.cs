using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	
	private GameObject routePanel;
	private GameObject taskPanel;
	private GameObject targetingPanel;



	// Use this for initialization
	void Start () {

		routePanel = GameObject.Find ("RoutePanel");
		taskPanel = GameObject.Find ("TaskPanel");
		targetingPanel = GameObject.Find ("TargetingPanel");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void waypointUI(){

		taskPanel.gameObject.SetActive(false);
		targetingPanel.gameObject.SetActive(false);
		routePanel.gameObject.SetActive(true);
		//thisPanel = routePanel;
	}

	public void targetingUI(){
		taskPanel.gameObject.SetActive(false);
		routePanel.gameObject.SetActive(false);
		targetingPanel.gameObject.SetActive(true);
		//thisPanel = targetingPanel;
	}

	public void taskUI(){
		routePanel.gameObject.SetActive(false);
		targetingPanel.gameObject.SetActive(false);
		taskPanel.gameObject.SetActive(true);
		//thisPanel = taskPanel;
	}
}
