using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	public static GameControl control;
  //  private MasterBlackBoard masterBlackBoard;
    [SerializeField]
    private List<FactionController> factionsList = new List<FactionController>();
    [SerializeField] private List<AnvilRoute> allGameRoutes;
    [SerializeField] private List<AnvilWayPoint> allGameWayPoints;
    [SerializeField] private List<AnvilAgent> allGameAgents;
    [SerializeField] private List<FactionController> allFactions;
    [SerializeField] private AnvilAgent activeAgent;

    void Awake () {
        
      
        if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} 
		else if (control != this) 
		{
			Destroy (gameObject);
		}
        
	}

    private void Start()
    {
        MasterBlackBoard.InitializeMasterBlackBoard();
        factionsList = MasterBlackBoard.allFactions;
        allGameRoutes = MasterBlackBoard.allGameRoutes;
        allGameWayPoints = MasterBlackBoard.allGameWayPoints;
        allGameAgents = MasterBlackBoard.allGameAgents;
    }

    private void Update()
    {
        UpdateMemory();
    }
    //establish and populate factions in the hierarchy so agents can be assigned.


    void OnGUI()
	{
		//OnGUI.Label(Put Lat long Data Here)
	}

    public List<FactionController> getFactionList()
    {
        return factionsList;
    }

    private void UpdateMemory()
    {
        factionsList = MasterBlackBoard.allFactions;
        allGameRoutes = MasterBlackBoard.allGameRoutes;
        allGameWayPoints = MasterBlackBoard.allGameWayPoints;
        allGameAgents = MasterBlackBoard.allGameAgents;
    }
}
