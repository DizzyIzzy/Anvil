﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBlackBoard : MonoBehaviour {

	public AnvilWayPoint navTgt;
	public AnvilRoute agentRoute;
	public List<GameObject> TargetList = new List<GameObject>();

	public GameObject weaponTgt;

	// Use this for initialization
	void Start () {

	
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setRoute(AnvilRoute route ){
		this.agentRoute = route;
	}

	public void setNavTgt(AnvilWayPoint target){
		this.navTgt = target;
	}

	public void setWeaponTgt(GameObject target){
		this.weaponTgt = target;
	}

}
