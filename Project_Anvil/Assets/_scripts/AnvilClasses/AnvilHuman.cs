using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilHuman : AnvilAgent {

    public string rank;
    [SerializeField] private string agentServiceNumber;
    [SerializeField] private int rankIndex;

    public float hunger;
	public float bladder; 
	public float fatigue;
	public float anxiety; 
    public float speed;
    
    public AnvilHuman()
    {
        this.hunger = 0;
        this.bladder = 0;
        this.fatigue = 0;
        this.anxiety = 0;
    }
    // Use this for initialization
    void Start ()
    {
        InitializeAgent();
        InitializeHuman();
    }

    private void InitializeHuman()
    {
        if (this.agentServiceNumber == "")
        {
            this.agentServiceNumber = randomValuesGenerator.GetHashedSerialNumber();
        }
        if (this.agentName == "")
        {
            this.agentName = randomValuesGenerator.GenerateName();
        }
        gameObject.name = agentName;
        if (this.rank == "")
        {
            string rankValues = randomValuesGenerator.GenerateRank();
            string rankIndexString = rankValues.Substring(0, 2);
            int.TryParse(rankIndexString, out rankIndex);
            rankValues = rankValues.Remove(0, 2);
            this.rank = rankValues;
        }
        if (this.task == "")
        {
            this.task = "Idle";
        }
    }


 
    // Update is called once per frame
    void Update () {
		
	}

    public int getRankIndex()
    {
        return this.rankIndex;
    }
}
