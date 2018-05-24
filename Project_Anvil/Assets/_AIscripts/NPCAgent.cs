using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAgent : MonoBehaviour {

	public int modelID;
	public string modelName;
	public int health;
	public WayPoint location;
	public WayPoint orientation;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void setHealth(int healthAmount)
	{
		this.health = healthAmount;
	}

	public void takeDamage(int damageAmount)
	{
		this.health = this.health - damageAmount;
	}

	public void setLocation( WayPoint goTo)
	{
		this.location = goTo;
	}


}
