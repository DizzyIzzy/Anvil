using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilHuman : AnvilAgent {

    public string rank;
    [SerializeField] private string agentServiceNumber;
    [SerializeField] private int rankIndex;

	public int maxHealth;
	public int currentHealth;

    public float hunger;
	public float bladder; 
	public float fatigue;
	public float anxiety; 


    public float speed;
    public float rotSpeed;
    public float distAccuracy;

	public int enemyCount;

    public float ammo;
    public float maxAmmo = 100;

    //public Animator patrolState;

	public List<GameObject> enemiesInMemory;
	//Air vehicles list
	//Water vehicles list
	//Land vehicles list
	//Ground Agent list
	//Water Agent list

	
    
    public AnvilHuman()
    {
		this.maxHealth = 100;
		this.currentHealth = maxHealth;
        this.hunger = 0;
        this.bladder = 0;
        this.fatigue = 0;
        this.anxiety = 0;

        this.speed = 2.0f;
        this.rotSpeed = 1.0f;
        this.distAccuracy = 3.0f;
        this.ammo = 100.0f;

		this.enemiesInMemory = new List<GameObject>();
    }
    // Use this for initialization
    void Start ()
    {
        InitializeAgent();
        InitializeHuman();

       // patrolState = GetComponent<Animator>();
    }

    private void InitializeHuman()
    {
        this.speed = 2.0f;
        this.rotSpeed = 1.0f;
        this.distAccuracy = 3.0f;

        enemyCount = 0;

        this.ammo = 100.0f;

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
		//checkEnemy();
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

    public GameObject getEnemy()
    {
        return enemiesInMemory[0];

    }


    /*
    public void checkEnemy()
    {
        if(enemiesInMemory.Count >= 1)
        {
            patrolState.SetBool("EngageBool", true);
        }
        else 
        {
            return;
        }
    }
    */




	public void doDamage(int damageAmount)
	{
		Debug.Log("Ouch my health is at: " + currentHealth);
		currentHealth -= damageAmount;
		healthCheck();
	}

	public void healthCheck()
	{
		if(currentHealth<= 0)
		{
			this.gameObject.SetActive(false);
		}
	}

	public void healAgent(int healAmount)
	{
		currentHealth += healAmount;
		if(currentHealth >= maxHealth)
		{
			currentHealth = maxHealth;
		}
	}

    public void reloadAmmo()
    {
        Invoke("reload", 2);
    }

    public void reload()
    {
        this.ammo = maxAmmo;
    }

}
