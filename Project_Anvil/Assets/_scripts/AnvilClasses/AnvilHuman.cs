using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilHuman : AnvilAgent {

	public float hunger;
	public float bladder; 
	public float fatigue;
	public float anxiety; 
	public float bladderMax;
    public float speed;

    public AnvilHuman()
    {
        this.agentSerial = "001";
        this.agentName = randomNameGenerator.generateName();
  
        this.hunger = 0;
        this.bladder = 0;
        this.fatigue = 0;
        this.anxiety = 0;


    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
