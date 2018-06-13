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
	public int enemyCount;


	public List<GameObject> enemiesInMemory; 
	//Air vehicles list
	//Water vehicles list
	//Land vehicles list
	//Ground Agent list
	//Water Agent list


    
    public AnvilHuman()
    {
        this.hunger = 0;
        this.bladder = 0;
        this.fatigue = 0;
        this.anxiety = 0;
		this.enemiesInMemory = new List<GameObject>();
    }
    // Use this for initialization
    void Start ()
    {
        InitializeAgent();
        InitializeHuman();
    }

    private void InitializeHuman()
    {
		enemyCount = 0;

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

		enemiesInMemory = new List<GameObject>();

    }


 
    // Update is called once per frame
    void Update () {
		
	}

    public int getRankIndex()
    {
        return this.rankIndex;
    }

	public void addEnemy(GameObject enemy)
	{
		

		if (!enemiesInMemory.Contains(enemy))
		{
			enemiesInMemory.Add(enemy);
			enemyCount++;
		}
	}



}
