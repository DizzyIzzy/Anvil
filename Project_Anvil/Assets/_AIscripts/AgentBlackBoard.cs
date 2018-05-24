using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBlackBoard : MonoBehaviour {

	public WayPoint navTgt;
	public Route agentRoute;
	public List<GameObject> TargetList = new List<GameObject>();

	public GameObject blackBoard;

	public GameObject weaponTgt;

	// Use this for initialization
	void Start () {

		blackBoard = GameObject.Find("BlackBoard");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setRoute(Route route ){
		this.agentRoute = route;
	}

	public void setNavTgt(WayPoint target){
		this.navTgt = target;
	}

	public void setWeaponTgt(GameObject target){
		this.weaponTgt = target;
	}

}
